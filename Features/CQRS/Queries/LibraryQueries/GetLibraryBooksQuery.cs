using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.LibraryQueries
{
    public class GetLibraryBooksQuery : IRequest<List<BookDto>>
    {
        public int LibraryId { get; set; }

        public GetLibraryBooksQuery(int libraryId)
        {
            LibraryId = libraryId;
        }
    }
}
