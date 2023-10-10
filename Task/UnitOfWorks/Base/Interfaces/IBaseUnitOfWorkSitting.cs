using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal interface IBaseUnitOfWorkSitting<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : BaseEntitySitting
    {
        Task<IEnumerable<TEntity>> Search(string searchText);
    }
}
