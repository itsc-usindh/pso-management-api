using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IUserRepository
    {
        Task<UserResponseModel> GetUserByUsernameAsync(string username);
        Task<ResponseModel> AddUserAsync(UserRequestModel payload);
    }
}
