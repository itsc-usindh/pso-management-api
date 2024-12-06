using Dapper;
using PSOManagement.Context;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;

        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserResponseModel> GetUserByUsernameAsync(string username)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string spName = "GetUserByUserName";

                var parameters = new
                {
                    Username = username
                };

                var user = await connection.QueryFirstOrDefaultAsync<UserResponseModel>(
                    spName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

                return user;
            }
        }

        public async Task<ResponseModel> AddUserAsync(UserRequestModel payload)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string spName = "CreateUser";

                var parameters = payload;

                var response = await connection.QueryFirstOrDefaultAsync<ResponseModel>(
                    spName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

                return response;
            }
        }

    }
}
