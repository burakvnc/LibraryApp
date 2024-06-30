using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Pages.Libraries
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryContext _context;

        public DetailsModel(LibraryContext context)
        {
            _context = context;
        }

        public Library? Library { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Library = await _context.Libraries
                                    .Include(l => l.LibraryBooks)
                                        .ThenInclude(lb => lb.Book)
                                            .ThenInclude(b => b.BookAuthors)
                                                .ThenInclude(ba => ba.Author)
                                    .Include(l => l.LibraryAuthors)
                                        .ThenInclude(la => la.Author)
                                    .FirstOrDefaultAsync(l => l.Id == id);

            if (Library == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
