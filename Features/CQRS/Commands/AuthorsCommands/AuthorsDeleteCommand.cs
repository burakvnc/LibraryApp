using MediatR;

namespace LibraryApp.Features.CQRS.Commands.AuthorCommands
{
    public class AuthorDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
