using ExpensesTracker.DAO.IService;
using ExpensesTracker.DAO.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpensesTracker.DAO.Service
{
    public class ServiceToken : IServiceToken
    {
        private readonly IConfiguration _config;

        public ServiceToken(
            IConfiguration config
            )
        {
            _config = config;
        }

        public string GenerateToken(AspNetUser user, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("Secret"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim("IdAspNetUser", user.Id.ToString()),
                    new Claim("IdUser", user.User.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            foreach (var role in roles)
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public CookieOptions GenerateCookies()
        {
            CookieOptions cookie = new CookieOptions();

            cookie.HttpOnly = true;

            return cookie;
        }
    }
}
