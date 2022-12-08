using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Services.Documents;
using LibraryManagementSystem.Application.Services.Files;
using LibraryManagementSystem.Infrastructure.DbContexts;
using LibraryManagementSystem.Infrastructure.Documents;
using LibraryManagementSystem.Infrastructure.Factories;
using LibraryManagementSystem.Infrastructure.Files;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileService, BlobStorageFileService>();
        services.AddScoped<IBookDocumentService, CosmosDbBookDocumentService>();

        services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        
        services.AddScoped<IApplicationDbContextFactory, ApplicationDbContextSqlServerFactory>();

        services.AddOptions<DatabaseOptions>().Bind(configuration.GetSection("DatabaseOptions"));
        services.AddOptions<BlobOptions>().Bind(configuration.GetSection("BlobOptions"));
        services.AddOptions<CosmosOptions>().Bind(configuration.GetSection("CosmosOptions"));

        return services;
    }
}