using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Commands.AuthorCommands
{
    public class AuthorUpdateCommand : IRequest<AuthorDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
