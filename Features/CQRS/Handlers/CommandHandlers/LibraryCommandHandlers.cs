using MediatR;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Features.CQRS.Commands.LibraryCommands;
using LibraryApp.Models;

namespace LibraryApp.Handlers.CommandHandlers
{
    public class LibraryCommandHandlers :
        IRequestHandler<LibraryCreateCommand, LibraryDto>,
        IRequestHandler<LibraryDeleteCommand, bool>,
        IRequestHandler<LibraryUpdateCommand, LibraryDto>,
        IRequestHandler<AddBookToLibraryCommand, bool>,
        IRequestHandler<RemoveBookFromLibraryCommand, bool>
    {
        private readonly LibraryContext _context;

        public LibraryCommandHandlers(LibraryContext context)
        {
            _context = context;
        }

        public async Task<LibraryDto> Handle(LibraryCreateCommand request, CancellationToken cancellationToken)
        {
            var library = new Library
            {
                Name = request.Name,
                Address = request.Address
            };

            _context.Libraries.Add(library);
            await _context.SaveChangesAsync(cancellationToken);

            return new LibraryDto
            {
                Id = library.Id,
                Name = library.Name,
                Address = library.Address
            };
        }

        public async Task<bool> Handle(LibraryDeleteCommand request, CancellationToken cancellationToken)
        {
            var library = await _context.Libraries.FindAsync(request.Id);
            if (library == null)
            {
                return false;
            }

            _context.Libraries.Remove(library);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<LibraryDto> Handle(LibraryUpdateCommand request, CancellationToken cancellationToken)
        {
            var library = await _context.Libraries.FindAsync(request.Id);
            if (library == null)
            {
                return null;
            }

            library.Name = request.Name;
            library.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);

            return new LibraryDto
            {
                Id = library.Id,
                Name = library.Name,
                Address = library.Address
            };
        }

        public async Task<bool> Handle(AddBookToLibraryCommand request, CancellationToken cancellationToken)
        {
            var libraryBook = new LibraryBook
            {
                LibraryId = request.LibraryId,
                BookId = request.BookId
            };

            _context.LibraryBooks.Add(libraryBook);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Handle(RemoveBookFromLibraryCommand request, CancellationToken cancellationToken)
        {
            var libraryBook = await _context.LibraryBooks
                .FirstOrDefaultAsync(lb => lb.LibraryId == request.LibraryId && lb.BookId == request.BookId);

            if (libraryBook == null)
            {
                return false;
            }

            _context.LibraryBooks.Remove(libraryBook);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
