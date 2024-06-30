using MediatR;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.DTOs;
using LibraryApp.Features.CQRS.Commands.BookCommands;


namespace LibraryApp.Handlers.CommandHandlers
{
    public class BookCommandHandlers :
        IRequestHandler<BookCreateCommand, BookDto>,
        IRequestHandler<BookDeleteCommand, bool>,
        IRequestHandler<BookUpdateCommand, BookDto>
    {
        private readonly LibraryContext _context;

        public BookCommandHandlers(LibraryContext context)
        {
            _context = context;
        }

        public async Task<BookDto> Handle(BookCreateCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                ISBN = request.ISBN,
                PublishedDate = request.PublishedDate
            };

            foreach (var authorId in request.AuthorIds)
            {
                book.BookAuthors.Add(new BookAuthor { AuthorId = authorId });
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate
            };
        }

        public async Task<bool> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<BookDto> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) return null;

            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.PublishedDate = request.PublishedDate;

            book.BookAuthors.Clear();
            foreach (var authorId in request.AuthorIds)
            {
                book.BookAuthors.Add(new BookAuthor { AuthorId = authorId });
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate
            };
        }
    }
}
