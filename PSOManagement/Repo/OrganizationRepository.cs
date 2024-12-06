using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DapperContext _dapperContext;

        public OrganizationRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<OrganizationResponseModel>> GetOrganization()
        {
            string query = "SELECT * FROM organizations";

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<OrganizationResponseModel>(query);

                return res.ToList();
            }
        }
        public async Task<OrganizationResponseModel> GetOrganizationById(int id)
        {
            string query = "SELECT * FROM organizations WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<OrganizationResponseModel>(query, new { Id = id });

                return result;
            }
        }
    }
}
