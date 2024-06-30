using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;


namespace LibraryApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                                 .Include(b => b.BookAuthors)
                                 .ThenInclude(ba => ba.Author)
                                 .ToListAsync();
        }
    }
}
