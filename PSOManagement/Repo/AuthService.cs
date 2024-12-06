using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PSOManagement.IRepo;
using PSOManagement.Model.Request;
using PSOManagement.Model.Response;

namespace PSOManagement.Repo
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(LoginRequestModel model)
        {
            var user = await _userRepository.GetUserByUsernameAsync(model.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) 
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role) ,
                new Claim("DepartmentId", user.DepartmentId.ToString()),
                new Claim("CampusId", user.CampusId.ToString()),
                new Claim("OrganizationId", user.OrganizationId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(5),  // Token expiration time 5 hpurs
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<ResponseModel> SignUp(UserRequestModel model)
        {
            // Check if the username already exists
            var existingUser = await _userRepository.GetUserByUsernameAsync(model.UserName);
            if (existingUser != null)
            {
                return new ResponseModel() { Msg= "User already exsist." ,Status=false};
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            model.Password = hashedPassword;
            

            return await _userRepository.AddUserAsync(model);
        }
    }
}
