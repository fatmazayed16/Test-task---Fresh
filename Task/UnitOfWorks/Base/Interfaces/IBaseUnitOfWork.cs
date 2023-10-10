using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestTask
{
    public interface IBaseUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> Read();
        Task<TEntity> Read(Guid id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);



    }
}