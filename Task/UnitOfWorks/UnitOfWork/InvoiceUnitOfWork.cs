using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask
{
    public class InvoiceUnitOfWork : BaseUnitOfWork<Invoice> , IInvoiceUnitOfWork { }
}