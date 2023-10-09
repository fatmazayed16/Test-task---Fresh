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
        private readonly IBillUnitOfWork _unitOfWork = new BillUnitOfWork();
        protected async Task Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                await HandelFormSubmit();
        }

        private async Task HandelFormSubmit()
        {
            if (Request.Form[$"net-value"] != string.Empty)
            {
                List<Item> items = new List<Item>();
                List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("Quantity")).ToList();

                foreach (string key in keys)
                {
                    string rowIndex = key.Replace("Quantity", "");
                    Item item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Item {rowIndex}",
                        Quantity = Request.Form[key],
                        Unit_Price = Request.Form[$"UnitPrice{rowIndex}"]
                    };

                    items.Add(item);
                }

                 Bill bill = new Bill()
                {
                    Item = items,
                    Total = Request.Form[$"net-value"]
                };

                await SaveBillResultInDb(bill);
            }
        }

        private async Task SaveBillResultInDb(Bill bill) => await _unitOfWork.Create(bill);
    }
}