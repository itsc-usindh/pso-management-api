using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DapperContext _dapperContext;

        public PurchaseRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<PurchaseResponseModel>> List(int organizationId, int maxRows)
        {
            string query = "GetPurhcaseList";
            var parameters = new {MaxRows = maxRows, OrganizationId = organizationId};

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<PurchaseResponseModel>(query, parameters);

                return res.ToList();
            }
        }

        public async Task<ResponseModel> Add(PurchaseModel payload, string userId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string spName = "addPurchase";
                var items = payload.Items.Select(item => $"{item.InventoryItemId},{item.Quantity},{item.Rate}");

                var parameters = new
                {
                    OrganizationId = payload.OrganizationId,
                    Items = string.Join(";", items),
                    OfficeOrderUrl = payload.OfficeOrderUrl,
                    OfficeOrderNumber = payload.OfficeOrderNumber,
                    PurchaseDate = payload.PurchaseDate,
                    UserId = userId
                };

                var response = await connection.QueryFirstOrDefaultAsync<ResponseModel>(
                    spName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

                return response;
            }
        }
    }
}
