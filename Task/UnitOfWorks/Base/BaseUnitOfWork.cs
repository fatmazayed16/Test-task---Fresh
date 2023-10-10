using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestTask
{
    public class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseReposatory<TEntity> _reposatory;

        protected BaseUnitOfWork() => _reposatory = BaseReposatory<TEntity>.BaseReposatoryInstance;

        public virtual async Task<IEnumerable<TEntity>> Read() => await _reposatory.Get();
        public virtual async Task<TEntity> Read(Guid id) => await _reposatory.Get(id);

        public async Task Create(TEntity entity)
        {
            DbContextTransaction transaction = await _reposatory.GetTransaction();

            try
            {
                await _reposatory.Add(entity);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task Update(TEntity entity)
        {
            DbContextTransaction transaction = await _reposatory.GetTransaction();

            try
            {
                await _reposatory.Update(entity);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task Delete(Guid id)
        {
            DbContextTransaction transaction = await _reposatory.GetTransaction();

            try
            {
                await _reposatory.Remove(id);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}
