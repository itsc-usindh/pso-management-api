namespace PSOManagement.Model.Request
{
    public class UserRequestModel
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
        public string? PortalConfigs { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
    }
}
