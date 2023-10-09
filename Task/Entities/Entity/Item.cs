using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Task
{
    public class Item : BaseEntitySitting
    {
        public string Quantity { get; set; }
        public string Unit_Price { get; set; }
        public Bill Bill { get; set; }
        public Guid BillId { get; set; }
    }
}
