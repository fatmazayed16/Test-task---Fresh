using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestTask
{
    public class BaseReposatory<TEntity> : IBaseReposatory<TEntity> where TEntity : BaseEntity
    {
        public readonly ApplicationDbContext _context;
        private static readonly object lockObject = new object();
        public static BaseReposatory<TEntity> instance;
        protected DbSet<TEntity> dbSet;

        protected BaseReposatory()
        {
            _context = new ApplicationDbContext();
            dbSet = _context.Set<TEntity>();
        }
        public static BaseReposatory<TEntity> BaseReposatoryInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new BaseReposatory<TEntity>();
                        }
                    }
                }
                return instance;
            }
        }

        public virtual async Task Add(TEntity entity)
        {
            ThrowExceptionIfParameterNotSupplied(entity);
            entity.Id = Guid.NewGuid();
            await Task.Run(()=> dbSet.Add(entity));
            await SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get() => await dbSet.ToListAsync(); 

        public virtual async Task<TEntity> Get(Guid id) 
            => await dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task Remove(Guid id)
        {
            TEntity entityFromDb = await ThrowExceptionIfEntityNotExistsInDatabase(id) ;
            await Task.Run(() => dbSet.Remove(entityFromDb));
            await SaveChangesAsync();
        }

        protected async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public virtual async Task Update(TEntity entity)
        {
            ThrowExceptionIfParameterNotSupplied(entity);
            TEntity entityFromDb = await ThrowExceptionIfEntityNotExistsInDatabase(entity);

            await Task.Run(() => _context.Entry(entityFromDb).CurrentValues.SetValues(entity));
            await SaveChangesAsync();
        }

        private static void ThrowExceptionIfParameterNotSupplied(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException($"{typeof(TEntity).Name} was not provided.");
        }

        protected async Task<TEntity> ThrowExceptionIfEntityNotExistsInDatabase(TEntity entity)
        {
            TEntity entityFromDb = await Get(entity.Id);
            if (entityFromDb == null)
                throw new ArgumentException($"{typeof(TEntity).Name} was not found in DB");

            return entityFromDb;
        }

        protected async Task<TEntity> ThrowExceptionIfEntityNotExistsInDatabase(Guid id)
        {
            TEntity entityFromDb = await Get(id);
            if (entityFromDb == null)
                throw new ArgumentException($"{typeof(TEntity).Name} was not found in DB");

            return entityFromDb;
        }

        public virtual async Task<DbContextTransaction> GetTransaction() => await Task.Run(() => _context.Database.BeginTransaction());
    }
}