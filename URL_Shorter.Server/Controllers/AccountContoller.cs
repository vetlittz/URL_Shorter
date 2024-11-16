using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using URL_Shorter.Server.Models;
using Microsoft.AspNetCore.Cors;

namespace URL_Shorter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Account> _passwordHasher;

        public AccountController(ApplicationDbContext context, IPasswordHasher<Account> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == model.Email);
            if (existingAccount != null)
            {
                return BadRequest("An account with this email already exists.");
            }

            var account = new Account
            {
                Email = model.Email,
                Password = _passwordHasher.HashPassword(null, model.Password),
                Admin = model.Admin 
            };


            _context.Accounts.Add(account);  
            await _context.SaveChangesAsync();  
            return Ok("Account registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == model.Email);
            if (existingAccount == null)
            {
                return BadRequest("No account found with this email.");
            }

            var result = _passwordHasher.VerifyHashedPassword(existingAccount, existingAccount.Password, model.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Incorrect password.");
            }

            return Ok("Login successful.");
        }

    }
}
