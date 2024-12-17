namespace PSOManagement.Model.Response
{
    public class GetUserResponseModel : UserResponseModel
    {
        public string Role { get; set; }
        public string RoleDescription { get; set; }
        public string Department { get; set; }
        public string DepartmentDescription { get; set; }
        public List<UserScreen> UserScreens { get; set; }
    }

    public class UserScreen{
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Config {  get; set; }

    }

}
