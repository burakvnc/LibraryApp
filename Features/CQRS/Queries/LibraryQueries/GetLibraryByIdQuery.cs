using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.LibraryQueries
{
    public class GetLibraryByIdQuery : IRequest<LibraryDto>
    {
        public int Id { get; set; }

        public GetLibraryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
