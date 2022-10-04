using LibraryManagementSystem.Application.Commands.AddLibrary;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(AddLibraryCommand).Assembly);

        return services;
    }
}