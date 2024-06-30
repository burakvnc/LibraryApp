using MediatR;
using LibraryApp.Features.CQRS.Commands.LibraryCommands;
using LibraryApp.Features.CQRS.Queries.LibraryQueries;
using LibraryApp.DTOs;
using LibraryApp.Handlers.CommandHandlers;
using LibraryApp.Handlers.QueryHandlers;

namespace LibraryApp.Services
{
    public static class LibraryServiceRegistration
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<LibraryCreateCommand, LibraryDto>, LibraryCommandHandlers>();
            services.AddTransient<IRequestHandler<LibraryDeleteCommand, bool>, LibraryCommandHandlers>();
            services.AddTransient<IRequestHandler<LibraryUpdateCommand, LibraryDto>, LibraryCommandHandlers>();
            services.AddTransient<IRequestHandler<GetLibraryByIdQuery, LibraryDto>, LibraryQueryHandlers>();
            services.AddTransient<IRequestHandler<GetLibrariesQuery, List<LibraryDto>>, LibraryQueryHandlers>();
            services.AddTransient<IRequestHandler<AddBookToLibraryCommand, bool>, LibraryCommandHandlers>();
            services.AddTransient<IRequestHandler<RemoveBookFromLibraryCommand, bool>, LibraryCommandHandlers>();

            return services;
        }
    }
}
