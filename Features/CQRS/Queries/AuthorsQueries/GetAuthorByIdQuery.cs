using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
