using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SSAI.Entity.DB;
using SSAI.Helpers;
using SSAI.Model.Request;
using SSAI.Model.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };


        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            AuthenticateResponse authResponse = null;

            try
            {
                var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                if (user == null) return null;

                var token = generateJwtToken(user);

                authResponse = (AuthenticateResponse)user;
                authResponse.Token = token;
            }
            catch (Exception) { }

            return authResponse;
        }


        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }


        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
