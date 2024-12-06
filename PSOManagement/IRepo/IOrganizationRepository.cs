using PSOManagement.Model.Response;

namespace PSOManagement.IRepo
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationResponseModel>> GetOrganization();
        Task<OrganizationResponseModel> GetOrganizationById(int id);
    }
}
