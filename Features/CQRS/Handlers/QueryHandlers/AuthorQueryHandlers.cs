using MediatR;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.DTOs;
using LibraryApp.Features.CQRS.Queries.AuthorQueries;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Handlers.QueryHandlers
{
    public class AuthorQueryHandlers :
        IRequestHandler<GetAuthorByIdQuery, AuthorDto>,
        IRequestHandler<GetAuthorsQuery, List<AuthorDto>>
    {
        private readonly LibraryContext _context;

        public AuthorQueryHandlers(LibraryContext context)
        {
            _context = context;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FindAsync(request.Id);
            if (author == null) return null;

            return new AuthorDto { Id = author.Id, Name = author.Name };
        }

        public async Task<List<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _context.Authors.ToListAsync(cancellationToken);

            return authors.Select(a => new AuthorDto { Id = a.Id, Name = a.Name }).ToList();
        }
    }
}
