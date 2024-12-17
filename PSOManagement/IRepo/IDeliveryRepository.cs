using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IDeliveryRepository
    {
        public Task<IEnumerable<DeliveryResponseModel>> List(int organizationId, int maxRows);
        public Task<ResponseModel> Add(DeliveryModel payload, string userId);
    }
}
