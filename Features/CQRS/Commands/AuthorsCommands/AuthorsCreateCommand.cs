using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Commands.AuthorCommands
{
    public class AuthorCreateCommand : IRequest<AuthorDto>
    {
        public string? Name { get; set; }
    }
}
