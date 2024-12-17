using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DapperContext _dapperContext;

        public DeliveryRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<DeliveryResponseModel>> List(int organizationId, int maxRows)
        {
            string query = "GetDevlveriesList";
            var parameters = new {MaxRows = maxRows, OrganizationId = organizationId};

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<DeliveryResponseModel>(query, parameters);

                return res.ToList();
            }
        }

        public async Task<ResponseModel> Add(DeliveryModel payload, string userId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string spName = "AddDelivery";
                var items = payload.Items.Select(item => $"{item.InventoryItemId},{item.Quantity}");

                var parameters = new
                {
                    DepartmentId = payload.DepartmentId,
                    Items = string.Join(";", items),
                    DeliveryOrderUrl = payload.DeliveryOrderUrl,
                    DeliveryOrderNumber = payload.DeliveryOrderNumber,
                    DeliveryProcessDate = payload.DeliveryProcessDate,
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
