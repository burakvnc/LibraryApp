using MediatR;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.DTOs;
using LibraryApp.Features.CQRS.Queries.BookQueries;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Handlers.QueryHandlers
{
    public class BookQueryHandlers :
        IRequestHandler<GetBookByIdQuery, BookDto>,
        IRequestHandler<GetBooksQuery, List<BookDto>>
    {
        private readonly LibraryContext _context;

        public BookQueryHandlers(LibraryContext context)
        {
            _context = context;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.Include(b => b.BookAuthors)
                                           .ThenInclude(ba => ba.Author)
                                           .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate
            };
        }

        public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.Include(b => b.BookAuthors)
                                            .ThenInclude(ba => ba.Author)
                                            .ToListAsync(cancellationToken);

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublishedDate = b.PublishedDate
            }).ToList();
        }
    }
}
