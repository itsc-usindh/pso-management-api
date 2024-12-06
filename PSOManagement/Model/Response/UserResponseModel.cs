namespace PSOManagement.Model.Response
{
    public class UserResponseModel : BaseModel
    {
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? CNIC { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public string? FacultyName { get; set; }
        public int CampusId { get; set; }
        public string? CampusName { get; set; }
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public string? PortalConfigs { get; set; }
        public int RoleId { get; set; }
        public string? Role { get; set; }
    }
}
