using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PatentWebApiProject.Data;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using System.Collections.Generic;
using System.Text;

namespace PatentWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IToken _tokenService;
        private readonly PatentContext context;

        public TokenController(IConfiguration configuration, PatentContext context, IToken tokenService)
        {
            _key = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(configuration["TokenKey"]!)
           );
            _tokenService = tokenService;
            this.context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var user = await context.members
           .FirstOrDefaultAsync(m => m.name == loginDto.name);

            if (user == null) return Unauthorized("Invalid username");

            if (user.email != loginDto.email)
                return Unauthorized("Invalid email");

            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                token,
                username = user.name,
                role = user.role,
            });
        }
    }
}
