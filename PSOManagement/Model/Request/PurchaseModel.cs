namespace PSOManagement.Model.Request
{
    public class PurchaseModel
    {
        public int OrganizationId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? VendorDetails { get; set; }
        public string? OfficeOrderNumber { get; set; }
        public string? OfficeOrderUrl { get; set; }
        public List<PurchaseItemModel>? Items { get; set; }
    }

}
