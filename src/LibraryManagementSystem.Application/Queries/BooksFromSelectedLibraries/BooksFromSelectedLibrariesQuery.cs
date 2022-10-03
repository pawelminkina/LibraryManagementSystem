using System.Security.Principal;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Models;
using LibraryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Queries.BooksFromSelectedLibraries;

public record BooksFromSelectedLibrariesQuery : IRequest<IEnumerable<BookDto>>
{
    public BooksFromSelectedLibrariesQuery()
    {
        
    }
    public BooksFromSelectedLibrariesQuery(string? titleStartsWith, IEnumerable<Guid> libraryIds)
    {
        TitleStartsWith = titleStartsWith;
        LibraryIds = libraryIds;
    }
    public string? TitleStartsWith { get; internal set; }
    public IEnumerable<Guid> LibraryIds { get; set; } = Enumerable.Empty<Guid>();
}

public class BooksFromSelectedLibrariesQueryHandler : IRequestHandler<BooksFromSelectedLibrariesQuery, IEnumerable<BookDto>>
{
    private readonly IApplicationDbContextFactory _dbContextFactory;

    public BooksFromSelectedLibrariesQueryHandler(IApplicationDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public async Task<IEnumerable<BookDto>> Handle(BooksFromSelectedLibrariesQuery request, CancellationToken cancellationToken)
    {
        //Usage of parallel approach really depends on needs and resources
        //In this case, one query is fine, but sometimes we need many of them; it's good to know how to do it
        const bool useParallelQueries = true;

        if (useParallelQueries)
            return await GetBooksWithManyQueries(request.LibraryIds, request.TitleStartsWith!);

        return await GetBooksWithOneQuery(request.LibraryIds, request.TitleStartsWith!);
    }

    private async Task<IEnumerable<BookDto>> GetBooksWithManyQueries(IEnumerable<Guid> libraryIds, string titleStartsWith)
    {
        var tasks = libraryIds.Select(s => Task.Run(() =>
        {
            var dbContext = _dbContextFactory.CreateNewDbContext();

            return dbContext.Books.Where(a => a.LibraryId == s && (a.Title.StartsWith(titleStartsWith) || string.IsNullOrWhiteSpace(titleStartsWith))).ToList();
        }));

        var books = await Task.WhenAll(tasks);

        return books.SelectMany(s => s.Select(MapToDto));
    }

    private async Task<IEnumerable<BookDto>> GetBooksWithOneQuery(IEnumerable<Guid> libraryIds, string titleStartsWith)
    {
        using var dbContext = _dbContextFactory.CreateNewDbContext();

        var query = dbContext.Books.Where(a => libraryIds.Any(d => d == a.LibraryId) && (a.Title.StartsWith(titleStartsWith) || string.IsNullOrWhiteSpace(titleStartsWith)));

        var books = await query.ToListAsync();

        return books.Select(MapToDto);
    }

    private bool TitleStartsWith(string title, string value)
    {
        if (string.IsNullOrWhiteSpace(title))
            return true;

        return title.StartsWith(value);
    }

    private static BookDto MapToDto(Book book) => new() { Title = book.Title, LibraryId = book.LibraryId.ToString()};
}