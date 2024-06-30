using MediatR;
using LibraryApp.DTOs;

namespace LibraryApp.Features.CQRS.Queries.LibraryQueries
{
    public class GetLibrariesQuery : IRequest<List<LibraryDto>>
    {
    }
}
