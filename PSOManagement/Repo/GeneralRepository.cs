using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly DapperContext _dapperContext;

        public GeneralRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<OrganizationResponseModel>> GetOrganization()
        {
            string query = "SELECT * FROM organizations WHERE isActive = 1";

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<OrganizationResponseModel>(query);

                return res.ToList();
            }
        }
        public async Task<OrganizationResponseModel> GetOrganizationById(int id)
        {
            string query = "SELECT * FROM organizations WHERE Id = @Id AND isActive = 1";

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<OrganizationResponseModel>(query, new { Id = id });

                return result;
            }
        }
        public async Task<IEnumerable<DepartmentResponseModel>> GetDepartments()
        {
            string query = "SELECT * FROM Departments WHERE isActive = 1";

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<DepartmentResponseModel>(query);

                return res.ToList();
            }
        }
        public async Task<IEnumerable<StatusResponseModel>> GetStatus()
        {
            string query = "SELECT * FROM Status WHERE isActive = 1";

            using (var connection = _dapperContext.CreateConnection())
            {
                var res = await connection.QueryAsync<StatusResponseModel>(query);

                return res.ToList();
            }
        }
    }
}
