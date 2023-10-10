using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask
{
    public class Invoice : BaseEntity
    {
        public string Total { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}