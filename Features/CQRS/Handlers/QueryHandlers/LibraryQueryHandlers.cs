using MediatR;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.DTOs;
using LibraryApp.Features.CQRS.Queries.LibraryQueries;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Handlers.QueryHandlers
{
    public class LibraryQueryHandlers :
        IRequestHandler<GetLibraryByIdQuery, LibraryDto>,
        IRequestHandler<GetLibrariesQuery, List<LibraryDto>>,
        IRequestHandler<GetLibraryBooksQuery, List<BookDto>>
    {
        private readonly LibraryContext _context;

        public LibraryQueryHandlers(LibraryContext context)
        {
            _context = context;
        }

        public async Task<LibraryDto> Handle(GetLibraryByIdQuery request, CancellationToken cancellationToken)
        {
            var library = await _context.Libraries.Include(l => l.LibraryBooks)
                                            .ThenInclude(lb => lb.Book)
                                            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
            if (library == null) return null;

            return new LibraryDto { Id = library.Id, Name = library.Name, Address = library.Address };
        }

        public async Task<List<LibraryDto>> Handle(GetLibrariesQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _context.Libraries.ToListAsync(cancellationToken);

            return libraries.Select(l => new LibraryDto { Id = l.Id, Name = l.Name, Address = l.Address }).ToList();
        }

        public async Task<List<BookDto>> Handle(GetLibraryBooksQuery request, CancellationToken cancellationToken)
        {
            var library = await _context.Libraries
                .Include(l => l.LibraryBooks)
                .ThenInclude(lb => lb.Book)
                .FirstOrDefaultAsync(l => l.Id == request.LibraryId, cancellationToken);

            return library?.LibraryBooks.Select(lb => new BookDto
            {
                Id = lb.Book.Id,
                Title = lb.Book.Title,
                ISBN = lb.Book.ISBN,
                PublishedDate = lb.Book.PublishedDate
            }).ToList() ?? new List<BookDto>();
        }
    }
}
