using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DapperContext _dapperContext;

        public InventoryRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<InventoryItemResponseModel>> List(int organizationId, int maxRows)
        {
            string query = "GetInventoryItems";
            var parameters = new { MaxRows = maxRows, OrganizationId = organizationId };

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<InventoryItemResponseModel>(query, parameters);

                return res.ToList();
            }
        }

        public async Task<ResponseModel> Update(InventoryItemModel payload, int userId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string spName = "updateInventory";

                var parameters = new
                {
                    Id = payload.Id,
                    Code = payload.Code,
                    Name = payload.Name,
                    Description = payload.Description,
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
