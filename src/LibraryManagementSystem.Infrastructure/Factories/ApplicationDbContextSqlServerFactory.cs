using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Infrastructure.DbContexts;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.Infrastructure.Factories;

public class ApplicationDbContextSqlServerFactory : IApplicationDbContextFactory
{
    private readonly IOptions<DatabaseOptions> _options;

    public ApplicationDbContextSqlServerFactory(IOptions<DatabaseOptions> options)
    {
        _options = options;
    }

    public IApplicationDbContext CreateNewDbContext() => new ApplicationDbContext(_options);
}