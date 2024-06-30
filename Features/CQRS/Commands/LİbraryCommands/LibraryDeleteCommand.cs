using MediatR;

namespace LibraryApp.Features.CQRS.Commands.LibraryCommands
{
    public class LibraryDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
