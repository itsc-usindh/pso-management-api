namespace PSOManagement.Model.Request
{
    public class PurchaseItemModel
    {
        public int InventoryItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}
