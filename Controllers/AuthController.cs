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
    
        
    }
}