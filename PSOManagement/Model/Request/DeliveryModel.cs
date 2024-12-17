namespace PSOManagement.Model.Request
{
    public class DeliveryModel
    {
        public int DepartmentId { get; set; }
        public DateTime DeliveryProcessDate { get; set; }
        public string? DeliveryOrderNumber { get; set; }
        public string? DeliveryOrderUrl { get; set; }
        public List<DeliveryItemModel>? Items { get; set; }
    }

}
