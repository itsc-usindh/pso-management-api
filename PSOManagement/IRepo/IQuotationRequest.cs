using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IQuotationRequest
    {
        Task<ResponseModel> Submit(QuotationRequestModel payload);
    }
}
