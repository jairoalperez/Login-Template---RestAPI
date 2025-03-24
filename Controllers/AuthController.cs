using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginTemplate_RestAPI.Models;
using LoginTemplate_RestAPI.Helpers;

namespace LoginTemplate_RestAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserInsert userInsert)
        {
            try
            {
                if (_context.Users.Any(u => u.UserName == userInsert.UserName || u.Email == userInsert.Email))
                {
                    return BadRequest(Messages.User.UserExists);
                }

                userInsert.Password = BCrypt.Net.BCrypt.HashPassword(userInsert.Password);

                var user = new User
                {
                    UserName = userInsert.UserName,
                    FirstName = userInsert.FirstName,
                    LastName = userInsert.LastName,
                    BirthDate = userInsert.BirthDate,
                    Email = userInsert.Email,
                    Password = userInsert.Password,
                    PhoneNumber = userInsert.PhoneNumber,
                    CurrentZip = userInsert.CurrentZip,
                    CurrentCity = userInsert.CurrentCity,
                    CurrentState = userInsert.CurrentState,
                    CurrentCountry = userInsert.CurrentCountry,
                    PlaceOfBirth = userInsert.PlaceOfBirth,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(Messages.User.Registered);
            }
            catch (Exception ex)
            {
                return Problem(Messages.Database.ProblemRelated, ex.Message);
            }
        }
    
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInsert loginInsert)
        {
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");

            if (string.IsNullOrEmpty(jwtKey))
            {
                return Problem(Messages.API.JWTNotConfigured);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginInsert.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginInsert.Password, user.Password))
            {
                return Unauthorized(Messages.User.WrongCredentials);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    ]
                ),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtIssuer,
                Audience = jwtIssuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwt = tokenHandler.WriteToken(token);

            return Ok(new
            {
                userId = user.UserId,
                username = user.UserName,
                token = jwt
            });
        }
    }
}