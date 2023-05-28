using boatappapi.Model;
using boatappapi.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using static BCrypt.Net.BCrypt;

namespace boatappapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> GetUserByUsernamePassword([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid user inputs");

            var possibleUser = _userService.GetUserByUsername(model.Username);

            if (possibleUser == null)
                return BadRequest("Invalid user inputs");

            if (!Verify(model.Password, possibleUser.Password))
                return BadRequest("Invalid user inputs");

            var token = GenerateJwtToken(possibleUser.Id.ToString());
            if (token == null)
                return StatusCode(500);

            return Ok(new { Token = token, Success = true });
        }

        private string GenerateJwtToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
