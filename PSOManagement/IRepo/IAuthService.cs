using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IAuthService
    {
        Task<string> Authenticate(LoginRequestModel model);
        Task<ResponseModel> SignUp(UserRequestModel model);
    }
}
