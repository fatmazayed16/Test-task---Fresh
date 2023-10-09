using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test_Task
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly IInvoiceUnitOfWork _unitOfWork = new InvoiceUnitOfWork();

        protected async Task Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                await HandelFormSubmit();
        }

        private async Task HandelFormSubmit()
        {
            if (Request.Form[$"net-value"] != string.Empty)
            {
                List<Items> items = new List<Items>();
                List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("Quantity")).ToList();

                foreach (string key in keys)
                {
                    string rowIndex = key.Replace("Quantity", "");
                    Items item = new Items()
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Item {rowIndex}",
                        Quantity = Request.Form[key],
                        UnitPrice = Request.Form[$"UnitPrice{rowIndex}"]
                    };

                    items.Add(item);
                }

                Invoice invoice = new Invoice()
                {
                    Items = items,
                    Total = Request.Form[$"net-value"]
                };

                await SaveBillResultInDb(invoice);
            }
        }

        private async Task SaveBillResultInDb(Invoice invoice) => await _unitOfWork.Create(invoice);
    }
}