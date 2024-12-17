using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IGeneralRepository
    {
        Task<IEnumerable<OrganizationResponseModel>> GetOrganization();
        Task<OrganizationResponseModel> GetOrganizationById(int id);
        Task<IEnumerable<DepartmentResponseModel>> GetDepartments();
        Task<IEnumerable<StatusResponseModel>> GetStatus();
    }
}
