using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IPurchaseRepository
    {
        public Task<IEnumerable<PurchaseResponseModel>> List(int organizationId, int maxRows);
        public Task<ResponseModel> Add(PurchaseModel payload, string userId);
    }
}
