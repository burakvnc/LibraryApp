using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Pages.Libraries
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        public IList<Library> Libraries { get; set; } = new List<Library>();

        public async Task OnGetAsync()
        {
            Libraries = await _context.Libraries.ToListAsync();
        }
    }
}
