using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using TestTask;

namespace TestTask
{
    public interface IBaseReposatory<TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> Get(Guid id);

        Task Update(TEntity entity);

        Task Remove(Guid id);
        Task<DbContextTransaction> GetTransaction();
    }
}