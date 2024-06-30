using MediatR;

namespace LibraryApp.Features.CQRS.Commands.LibraryCommands
{
    public class RemoveBookFromLibraryCommand : IRequest<bool>
    {
        public int LibraryId { get; set; }
        public int BookId { get; set; }
    }
}
