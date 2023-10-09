using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    internal interface IBaseReposatory<TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> Get(Guid id);

        Task Update(TEntity entity);

        Task Remove(Guid id);
        Task<DbContextTransaction> GetTransaction();
    }
}
