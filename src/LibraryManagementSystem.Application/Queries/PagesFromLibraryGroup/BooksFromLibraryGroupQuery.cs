using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryManagementSystem.Application.Queries.PagesFromLibraryGroup;

public record BooksFromLibraryGroupQuery : IRequest<BooksFromLibraryGroupQueryDto>
{
    public Guid GroupId { get; }

    public BooksFromLibraryGroupQuery(Guid groupId)
    {
        GroupId = groupId;
    }
}

//First option using repository pattern and filtering whole object
//public class BooksFromLibraryGroupQueryHandler : IRequestHandler<BooksFromLibraryGroupQuery, BooksFromLibraryGroupQueryDto>
//{
//    private readonly ILibraryGroupRepository _libraryGroupRepository;

//    public BooksFromLibraryGroupQueryHandler(ILibraryGroupRepository libraryGroupRepository)
//    {
//        _libraryGroupRepository = libraryGroupRepository;
//    }

//    public async Task<BooksFromLibraryGroupQueryDto> Handle(BooksFromLibraryGroupQuery request, CancellationToken cancellationToken)
//    {
//        var libraryGroup = await _libraryGroupRepository.GetGroup(request.GroupId);
//        if (libraryGroup == null)
//            throw new ArgumentException("Given library group id is not correct");


//        var librariesWithBooks = libraryGroup.Libraries.Select(MapToDto);

//        return new BooksFromLibraryGroupQueryDto() { LibrariesWithBooks = librariesWithBooks, LibraryGroupName = libraryGroup.Name };
//    }

//    private static LibraryWithBooks MapToDto(Library entity) => new()
//    {
//        LibraryName = entity.Name,
//        BooksContent = entity.Books.Select(a => string.Join(' ', a.Pages.OrderBy(s => s.Number).Select(d => d.Content)))
//    };
//}

//Second option: translating object to dto, using in group method with select
//public class BooksFromLibraryGroupQueryHandler : IRequestHandler<BooksFromLibraryGroupQuery, BooksFromLibraryGroupQueryDto>
//{
//    private readonly IApplicationDbContext _dbContext;

//    public BooksFromLibraryGroupQueryHandler(IApplicationDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public async Task<BooksFromLibraryGroupQueryDto> Handle(BooksFromLibraryGroupQuery request, CancellationToken cancellationToken)
//    {
//        var libraryGroup = _dbContext.LibraryGroups.FirstOrDefault(s => s.Id == request.GroupId);
//        if (libraryGroup == null)
//            throw new ArgumentException("Given library group id is not correct");

//        //If we want to use external method to map, we've to use includes too
//        var librariesWithBooks = await _dbContext
//            .Libraries.Where(s => s.LibraryGroup.Id == request.GroupId)
//            .Include(s=>s.Books)
//            .ThenInclude(s=>s.Pages)
//            .Select(s => MapToDto(s))
//            .ToListAsync(cancellationToken);

//        return new BooksFromLibraryGroupQueryDto() { LibrariesWithBooks = librariesWithBooks, LibraryGroupName = libraryGroup.Name };
//    }

//    private static LibraryWithBooks MapToDto(Library entity) => new()
//    {
//        LibraryName = entity.Name,
//        BooksContent = entity.Books.Select(a => string.Join(' ', a.Pages.OrderBy(s => s.Number).Select(d => d.Content)))
//    };
//}

//Third option: translating object to dto on select, using inline syntax
public class BooksFromLibraryGroupQueryHandler : IRequestHandler<BooksFromLibraryGroupQuery, BooksFromLibraryGroupQueryDto>
{
    private readonly IApplicationDbContext _dbContext;

    public BooksFromLibraryGroupQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BooksFromLibraryGroupQueryDto> Handle(BooksFromLibraryGroupQuery request, CancellationToken cancellationToken)
    {
        //Even though syntax looks better for FirstOrDefault(s => s.Id == request.GroupId), using the one below is more efficient in Database
        var libraryGroupName = _dbContext.LibraryGroups.Where(a=>a.Id == request.GroupId).Select(s=>s.Name).FirstOrDefault();
        if (string.IsNullOrEmpty(libraryGroupName))
            throw new ArgumentException("Given library group id is not correct");

        var librariesWithBooks = await _dbContext
            .Libraries.Where(s => s.LibraryGroup.Id == request.GroupId)
            .Select(s => new LibraryWithBooks()
            {
                LibraryName = s.Name,
                BooksContent = s.Books.Select(a => string.Join(' ', a.Pages.OrderBy(s => s.Number).Select(d => d.Content)))
            }).ToListAsync(cancellationToken);

        return new BooksFromLibraryGroupQueryDto() { LibrariesWithBooks = librariesWithBooks, LibraryGroupName = libraryGroupName };
    }
}