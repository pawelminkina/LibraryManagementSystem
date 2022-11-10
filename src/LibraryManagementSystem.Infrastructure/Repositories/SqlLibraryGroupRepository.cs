using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Repositories;

public class SqlLibraryGroupRepository : ILibraryGroupRepository
{
    private readonly IApplicationDbContext _dbContext;

    public SqlLibraryGroupRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<LibraryGroup> GetGroup(Guid groupId)
    {
        var group = await _dbContext.LibraryGroups
            .Include(s=>s.Libraries)
            .ThenInclude(s=>s.Books)
            .ThenInclude(s=>s.Pages)
            .FirstOrDefaultAsync(s => s.Id == groupId);

        return group!;
    }
}