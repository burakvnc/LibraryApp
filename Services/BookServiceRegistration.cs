using MediatR;
using LibraryApp.Features.CQRS.Commands.BookCommands;
using LibraryApp.Features.CQRS.Queries.BookQueries;
using LibraryApp.DTOs;
using LibraryApp.Handlers.CommandHandlers;
using LibraryApp.Handlers.QueryHandlers;

namespace LibraryApp.Services
{
    public static class BookServiceRegistration
    {
        public static IServiceCollection AddBookServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<BookCreateCommand, BookDto>, BookCommandHandlers>();
            services.AddTransient<IRequestHandler<BookDeleteCommand, bool>, BookCommandHandlers>();
            services.AddTransient<IRequestHandler<BookUpdateCommand, BookDto>, BookCommandHandlers>();
            services.AddTransient<IRequestHandler<GetBookByIdQuery, BookDto>, BookQueryHandlers>();
            services.AddTransient<IRequestHandler<GetBooksQuery, List<BookDto>>, BookQueryHandlers>();
            return services;
        }
    }
}
