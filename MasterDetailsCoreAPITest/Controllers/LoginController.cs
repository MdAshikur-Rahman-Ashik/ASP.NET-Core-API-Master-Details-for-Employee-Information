using MasterDetailsCoreAPITest.Models;
using MasterDetailsCoreAPITest.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MasterDetailsCoreAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        IConfiguration _configuration;
        public LoginController(AppDbContext db, IConfiguration configuration)
        {
            _context = db;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> PostLoginDetails(UserModel _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _context.TblUsers
                    .Where(e => e.EmailId == _userData.EmailId && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null){
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    _userData.UserMessage = "Login Success";
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", _userData.ID.ToString()),
                        new Claim("DisplayName", _userData.FullName),
                        new Claim("UserName", _userData.FullName),
                        new Claim("Email", _userData.EmailId)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(50),
                        signingCredentials: signIn);
                    _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(_userData);
                }
            }
            else {
                return BadRequest("No Data Posted");
            }
        }
    }
}
