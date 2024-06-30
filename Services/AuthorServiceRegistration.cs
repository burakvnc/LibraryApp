using MediatR;
using LibraryApp.Features.CQRS.Commands.AuthorCommands;
using LibraryApp.Features.CQRS.Queries.AuthorQueries;
using LibraryApp.DTOs;
using LibraryApp.Handlers.CommandHandlers;
using LibraryApp.Handlers.QueryHandlers;

namespace LibraryApp.Services
{
    public static class AuthorServiceRegistration
    {
        public static IServiceCollection AddAuthorServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AuthorCreateCommand, AuthorDto>, AuthorCommandHandlers>();
            services.AddTransient<IRequestHandler<AuthorDeleteCommand, bool>, AuthorCommandHandlers>();
            services.AddTransient<IRequestHandler<AuthorUpdateCommand, AuthorDto>, AuthorCommandHandlers>();
            services.AddTransient<IRequestHandler<GetAuthorByIdQuery, AuthorDto>, AuthorQueryHandlers>();
            services.AddTransient<IRequestHandler<GetAuthorsQuery, List<AuthorDto>>, AuthorQueryHandlers>();
            return services;
        }
    }
}
