using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Commands.LibraryCommands
{
    public class LibraryUpdateCommand : IRequest<LibraryDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
