using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskWebAPI.Models;

namespace TaskWebAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("get-token")]
        public IActionResult GetToken([FromBody] ApiKeyRequest request)
        {
           
            var validApiKey = _configuration["ApiKey"]; 

            if (request.ApiKey != validApiKey)
            {
                return Unauthorized();
            }

    
            var claims = new[]
            {
                new Claim("Role", "User") 
            };

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

       
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

           
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

