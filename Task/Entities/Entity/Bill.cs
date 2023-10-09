using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Task
{
    public class Bill : BaseEntity
    {
        public string Total { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}