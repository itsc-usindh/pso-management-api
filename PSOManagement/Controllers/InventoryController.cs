using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;
using PSOManagement.Repo;

namespace PSOManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<InventoryItemResponseModel>>> List([FromQuery] int maxRow = 100)
        {
            int organizationId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value);

            var inventoryList = await _inventoryRepository.List(organizationId, maxRow);

            return Ok(inventoryList);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<ResponseModel>> Update(InventoryItemModel payload)
        {
            string _userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            int userId = int.Parse(_userId);

            var res = await _inventoryRepository.Update(payload, userId);
            return Ok(res);
        }
    }
}
