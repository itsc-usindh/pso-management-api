using System.ComponentModel;
using PSOManagement.Model.Request;

namespace PSOManagement.Model.Response
{
    public class PurchaseResponseModel : BaseModel
    {
        public int OrganizationId { get; set; }
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? Purchase { get; set; }
        public string? VendorDetails { get; set; }
        public string? Organization { get; set; }
        public string? OfficeOrderNumber { get; set; }
        public string? OfficeOrderUrl { get; set; }
        public string? ItemsString { get; set; }
        public List<PurchaseItemResponseModel>? Items {
            get
            {
                List<PurchaseItemResponseModel> _Items = new List<PurchaseItemResponseModel>();
                string[] rows = this.ItemsString.Split(";");
                foreach (var row in rows)
                {
                    string[] columns = row.Split(",");
                    _Items.Add(new PurchaseItemResponseModel
                    {
                        Code = columns[0],
                        Name = columns[1],
                        Description = columns[2],
                        Quantity = decimal.Parse(columns[3]),
                        Rate = decimal.Parse(columns[4])
                    });
                };
                return _Items;
            }
        }
    }
}
