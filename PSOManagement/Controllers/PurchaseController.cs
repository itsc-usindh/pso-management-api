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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<PurchaseResponseModel>>> List([FromQuery] int maxRow= 100)
        {
            int organizationId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value);

            var purchaseList = await _purchaseRepository.List(organizationId, maxRow);

            return Ok(purchaseList);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ResponseModel>> Add(PurchaseModel payload)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            string organizationId = User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;

            payload.OrganizationId = int.Parse(organizationId??"");

            var res = await _purchaseRepository.Add(payload, userId);
            return Ok(true);
        }
    }
}
