using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Task
{
    public class Invoice : BaseEntity
    {
        public string Total { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}