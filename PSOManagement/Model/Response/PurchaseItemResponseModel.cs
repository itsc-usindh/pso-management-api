namespace PSOManagement.Model.Response
{
    public class PurchaseItemResponseModel
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}
