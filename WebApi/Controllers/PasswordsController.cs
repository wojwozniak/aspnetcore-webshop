using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly ShopDbContext _context;


        public PasswordsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Passwords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Password>>> GetPasswords()
        {
            var passwords = await _context.Passwords.ToListAsync();
            return Ok(passwords);
        }

        // GET: api/Passwords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Password>> GetPassword(int id)
        {
            var password = await _context.Passwords.FirstOrDefaultAsync(p => p.Password_ID == id);

            if (password == null)
            {
                return NotFound();
            }

            return Ok(password);
        }

        // POST: api/Passwords
        [HttpPost]
        public async Task<ActionResult<Password>> PostPassword(Password password)
        {
            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPassword), new { id = password.Password_ID }, password);
        }

        // PUT: api/Passwords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassword(int id, Password password)
        {
            if (id != password.Password_ID)
            {
                return BadRequest();
            }

            _context.Entry(password).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Passwords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasswordExists(int id)
        {
            return _context.Passwords.Any(e => e.Password_ID == id);
        }
    }
}
