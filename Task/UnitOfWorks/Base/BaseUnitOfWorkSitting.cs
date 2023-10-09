using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Test_Task
{
    public class BaseUnitOfWorkSitting<TEntity> : BaseUnitOfWork<TEntity>,
        IBaseUnitOfWorkSitting<TEntity> where TEntity : BaseEntitySitting
    {
        public Task<IEnumerable<TEntity>> Search(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}