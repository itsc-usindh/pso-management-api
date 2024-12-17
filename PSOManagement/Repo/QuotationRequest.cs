using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class QuotationRequest: IQuotationRequest
    {
        private readonly DapperContext _dapperContext;

        public QuotationRequest(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<ResponseModel> Submit(QuotationRequestModel payload)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string spName = "submitRequestForQuotation";

                var parameters = new
                {
                    Description = payload.Description,
                    OfficeOrderNumber = payload.OfficeOrderNumber,
                    OfficeOrderUrl = payload.OfficeOrderUrl,
                    RequestedBy = payload.RequestedBy,
                    DepartmentId = payload.DepartmentId,
                    StatusId = payload.StatusId,
                    UserId = payload.RequestedBy
                };

                var response = await connection.QueryFirstOrDefaultAsync<ResponseModel>(
                    spName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

                return response;
            }
    }
}
