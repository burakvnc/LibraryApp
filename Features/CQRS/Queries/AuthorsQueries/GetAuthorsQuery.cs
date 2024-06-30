using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.AuthorQueries
{
    public class GetAuthorsQuery : IRequest<List<AuthorDto>>
    {
    }
}
