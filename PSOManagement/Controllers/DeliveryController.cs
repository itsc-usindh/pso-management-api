using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryRepository _DeliveryRepository;

        public DeliveryController(IDeliveryRepository DeliveryRepository)
        {
            _DeliveryRepository = DeliveryRepository;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<DeliveryResponseModel>>> List([FromQuery] int maxRow= 100)
        {
            int organizationId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value);

            var DeliveryList = await _DeliveryRepository.List(organizationId, maxRow);

            return Ok(DeliveryList);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ResponseModel>> Add(DeliveryModel payload)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var res = await _DeliveryRepository.Add(payload, userId);
            return Ok(res);
        }
    }
}
