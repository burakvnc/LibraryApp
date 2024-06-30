using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Commands.LibraryCommands
{
    public class LibraryCreateCommand : IRequest<LibraryDto>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
