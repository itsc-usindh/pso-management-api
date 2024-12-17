using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PSOManagement.Model.Request
{
    public class InventoryItemModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
