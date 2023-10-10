using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask
{
    public class Items : BaseEntitySitting
    {
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public virtual Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
