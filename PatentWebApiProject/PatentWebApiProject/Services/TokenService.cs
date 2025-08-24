using Microsoft.IdentityModel.Tokens;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PatentWebApiProject.Services
{
    public class TokenService : IToken
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(config["TokenKey"]!)
           );
        }

        public string GenerateToken(Members mem)
        {
            var claims = new List<Claim>
              {
                 new Claim(ClaimTypes.NameIdentifier, mem.memId.ToString()),
                 new Claim(ClaimTypes.Name, mem.name!),
                 new Claim(ClaimTypes.Role, mem.role!)
              };

            string token = string.Empty;

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = cred,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
    }
}
