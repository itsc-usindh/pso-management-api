namespace PSOManagement.Model.Request
{
    public class QuotationRequestModel
    {
        public string? Description { get; set; }
        public string? OfficeOrderNumber { get; set; }
        public string? OfficeOrderUrl { get; set; }
        public int? DepartmentId { get; set; }
        public int? RequestedBy { get; set; }
        public DateTime RequestedOn { get; set; }
        public int DeliveryId { get; set; }
        public int StatusId { get; set; }
    }
}
