using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Commands.BookCommands
{
    public class BookCreateCommand : IRequest<BookDto>
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<int>? AuthorIds { get; set; }
    }
}
