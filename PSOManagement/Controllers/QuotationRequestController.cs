using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PSOManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuotationRequestController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
