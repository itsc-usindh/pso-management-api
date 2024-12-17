namespace PSOManagement.Model.Response
{
    public class DeliveryResponseModel
    {
        public int DepartmentId { get; set; }
        public int DeliveryId { get; set; }
        public DateTime DeliveryProcessDate { get; set; }
        public string? Deliverables { get; set; }
        public string? Department { get; set; }
        public string? DeliveryOrderNumber { get; set; }
        public string? DeliveryOrderUrl { get; set; }
        public string? ItemsString { get; set; }
        public List<DeliveryItemResponseModel>? Items
        {
            get
            {
                List<DeliveryItemResponseModel> _Items = new List<DeliveryItemResponseModel>();
                string[] rows = this.ItemsString.Split(";");
                foreach (var row in rows)
                {
                    string[] columns = row.Split(",");
                    _Items.Add(new DeliveryItemResponseModel
                    {
                        Code = columns[0],
                        Name = columns[1],
                        Description = columns[2],
                        Quantity = decimal.Parse(columns[3]),
                    });
                };
                return _Items;
            }
        }
    }
}
