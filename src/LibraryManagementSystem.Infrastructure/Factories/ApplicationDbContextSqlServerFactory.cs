using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Infrastructure.DbContexts;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.Infrastructure.Factories;

public class ApplicationDbContextSqlServerFactory : IApplicationDbContextFactory
{
    private readonly IOptions<DatabaseOptions> _options;

    public ApplicationDbContextSqlServerFactory(IOptions<DatabaseOptions> options)
    {
        _options = options;
    }

    public IApplicationDbContext CreateNewDbContext()
    {
        var dbOptions = new DbContextOptionsBuilder(new DbContextOptions<ApplicationDbContext>());
        return new ApplicationDbContext(dbOptions.Options, _options);
    }
}