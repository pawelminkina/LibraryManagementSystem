using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.Infrastructure.DbContexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IOptions<DatabaseOptions>? _options;

    public ApplicationDbContext(IOptions<DatabaseOptions> options)
    {
        _options = options;
    }

    public ApplicationDbContext()
    {
        
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Library> Libraries { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //For test purpose
        if (_options is null)
            return;

        optionsBuilder.UseSqlServer(_options.Value.ConnectionString!);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}