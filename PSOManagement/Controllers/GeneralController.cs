using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSOManagement.IRepo;
using PSOManagement.Model.Response;

namespace PSOManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralRepository _organizationRepository;

        public GeneralController(IGeneralRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet("GetOrganization")]
        public async Task<IEnumerable<OrganizationResponseModel>> GetOrganization()
        {
            var organizations = await _organizationRepository.GetOrganization();

            return organizations;
        }

        [HttpGet("GetOrganizationById/{id}")]
        public async Task<OrganizationResponseModel> GetOrganizationById(int Id)
        {
            var organizations = await _organizationRepository.GetOrganizationById(Id);

            return organizations;
        }
        [HttpGet("GetDepartments")]
        public async Task<IEnumerable<DepartmentResponseModel>> GetDepartments()
        {
            var departments = await _organizationRepository.GetDepartments();

            return departments;
        }
        [HttpGet("GetStatus")]
        public async Task<IEnumerable<StatusResponseModel>> GetStatus()
        {
            var status = await _organizationRepository.GetStatus();

            return status;
        }
    }
}
