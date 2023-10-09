using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    internal interface IBaseReposatorySetting<TEntity> : IBaseReposatory<TEntity> where TEntity : BaseEntitySitting
    {
        Task<IEnumerable<TEntity>> Search(string searchText);
    }
}
