using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataResetController : ControllerBase
    {
        private readonly LibraryContext _context;

        public DataResetController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetDatabase()
        {
            _context.Books.RemoveRange(_context.Books);
            _context.Authors.RemoveRange(_context.Authors);
            _context.Libraries.RemoveRange(_context.Libraries);
            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Books', RESEED, 0);");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Authors', RESEED, 0);");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Libraries', RESEED, 0);");

            return Ok("Veritabanı sıfırlandı ve kimlik sütunları sıfırlandı.");
        }
    }
}
