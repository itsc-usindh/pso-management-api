using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItemResponseModel>> List(int organizationId, int maxRows);
        Task<ResponseModel> Update(InventoryItemModel payload, int userId);
    }
}
