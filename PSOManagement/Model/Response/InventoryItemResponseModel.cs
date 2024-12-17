namespace PSOManagement.Model.Response
{
    public class InventoryItemResponseModel:BaseModel
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? AvailableQuantity { get; set; }
        public double? DeliverQuantity { get; set; }
        public double? PurchaseQuantity { get; set; }
    }
}
