using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Task
{
    public class InvoiceUnitOfWork : BaseUnitOfWork<Invoice> , IInvoiceUnitOfWork { }
}