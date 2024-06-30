using MediatR;

namespace LibraryApp.Features.CQRS.Commands.BookCommands
{
    public class BookDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
