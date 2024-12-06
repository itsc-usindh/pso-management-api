using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService loginService)
        {
            _authService = loginService;
        }

        [HttpPost("quickLogin")]
        public async Task<ActionResult<string>> QuickLogin()
        {
            LoginRequestModel loginRequest = new LoginRequestModel() { UserName="aimal",Password="abc123"};
            var token = await _authService.Authenticate(loginRequest);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(token);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequestModel loginRequest)
        {
            var token = await _authService.Authenticate(loginRequest);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }

        [HttpPost("signup")]
        public async Task<ActionResult<ResponseModel>> SignUp(UserRequestModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            model.CreatedBy = int.Parse(userId);
            return await _authService.SignUp(model);
        }
    }
}
