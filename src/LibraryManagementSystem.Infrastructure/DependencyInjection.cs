using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Infrastructure.DbContexts;
using LibraryManagementSystem.Infrastructure.Factories;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        
        services.AddScoped<IApplicationDbContextFactory, ApplicationDbContextSqlServerFactory>();

        services.AddOptions<DatabaseOptions>().Bind(configuration.GetSection("DatabaseOptions"));

        return services;
    }
}