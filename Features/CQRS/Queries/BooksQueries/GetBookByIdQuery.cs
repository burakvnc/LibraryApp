using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.BookQueries
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
