using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(ShopDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == loginRequest.Email);
            if (user is not null)
            {
                var passwordRecord = _context.Passwords.FirstOrDefault(p => p.User_ID == user.User_ID);
                if (passwordRecord is not null)
                {
                    var hashedPassword = HashPassword(loginRequest.Password, passwordRecord.Salt);
                    if (hashedPassword == passwordRecord.Password_Hash)
                    {
                        // Generate JWT token
                        var token = _tokenService.GenerateToken(user.Name, user.Email, new List<string> { user.Role });

                        return Ok(new LoginResponse
                        {
                            Token = token
                        });
                    }
                }
            }

            return Unauthorized(new { message = "Invalid email or password" });
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.Users
                .Where(u => u.Email == registerRequest.Email)
                .FirstOrDefaultAsync();

            if (existingUser is not null)
            {
                return Conflict(new { message = "User with this email already exists." });
            }

            var user = new User()
            {
                Email = registerRequest.Email,
                Role = "U",
                Address = registerRequest.Address,
                Phone_Number = registerRequest.Phone_Number,
                Name = registerRequest.Name
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var savedUser = _context.Users.Where(u => u.Email == user.Email);
            if (savedUser is not null)
            {
                var salt = GenerateSalt();
                var hashedPassword = HashPassword(registerRequest.Password, salt);
                var password = new Password
                {
                    User_ID = user.User_ID,
                    Password_Hash = hashedPassword,
                    Salt = salt,
                    HashRounds = 10000,
                    PasswordSetDate = DateTime.Now
                };
                _context.Passwords.Add(password);
                await _context.SaveChangesAsync();

                // Generate JWT token for the newly registered user
                var token = _tokenService.GenerateToken(user.Name, user.Email, new List<string> { user.Role });

                return CreatedAtAction(nameof(Register),
                    new { id = user.User_ID },
                    new RegisterResponse
                    {
                        Token = token,
                        Message = "User registered successfully"
                    });
            }
            return Conflict(new { message = "Saving failed." });
        }

        [HttpPost("login-google")]
        public ActionResult<ChallengeResult> LoginWithGoogle()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, "Google");
        }

        [HttpGet("google-callback")]
        public async Task<ActionResult<LoginResponse>> GoogleCallback()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
                return Unauthorized();

            var claims = authenticateResult.Principal.Identities.FirstOrDefault()?.Claims;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            // Check if user exists in the database - if not, register
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    Name = name,
                    Role = "U"
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            // Generate JWT token for Google login
            var token = _tokenService.GenerateToken(user.Name, user.Email, new List<string> { user.Role });

            return Ok(new LoginResponse
            {
                Token = token
            });
        }

        private string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buffer = new byte[16];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        private string HashPassword(string password, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000);
            return Convert.ToBase64String(pbkdf2.GetBytes(32));
        }
    }
}
