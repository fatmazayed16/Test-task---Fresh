using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Test_Task
{
    public class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseReposatory<TEntity> _reposatory;
        protected BaseUnitOfWork() => _reposatory = BaseReposatory<TEntity>.BaseReposatoryInstance;


        public async Task Create(TEntity entity)
        {
            DbContextTransaction transaction = await _reposatory.GetTransaction();
            try
            {
                await _reposatory.Add(entity);
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}