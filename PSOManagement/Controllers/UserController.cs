using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSOManagement.IRepo;
using PSOManagement.Model.Response;

namespace PSOManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("GetUser")]
        public async Task<ActionResult<GetUserResponseModel>> GetUser()
        {
            string _userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            int userId = int.Parse(_userId);
            GetUserResponseModel res = await _userRepository.GetUserById(userId);
            res.Password = "Encrypted";
            return Ok(res);
        }
    }
}
