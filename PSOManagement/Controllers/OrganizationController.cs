using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSOManagement.IRepo;
using PSOManagement.Model.Response;

namespace PSOManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet(Name = "GetOrganization")]
        public async Task<IEnumerable<OrganizationResponseModel>> GetOrganization()
        {
            var organizations = await _organizationRepository.GetOrganization();

            return organizations;
        }

        [HttpGet("id", Name = "GetOrganizationById")]
        public async Task<OrganizationResponseModel> GetOrganizationById(int Id)
        {
            var organizations = await _organizationRepository.GetOrganizationById(Id);

            return organizations;
        }
    }
}
