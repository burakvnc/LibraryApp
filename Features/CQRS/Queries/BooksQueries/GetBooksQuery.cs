using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.BookQueries
{
    public class GetBooksQuery : IRequest<List<BookDto>>
    {
    }
}
