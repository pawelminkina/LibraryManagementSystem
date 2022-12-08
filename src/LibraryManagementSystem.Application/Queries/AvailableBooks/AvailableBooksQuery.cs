using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Models;
using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Queries.AvailableBooks;

public class AvailableBooksQuery : IRequest<IEnumerable<BookDto>>
{

}

public class AvailableBooksQueryHandler : IRequestHandler<AvailableBooksQuery, IEnumerable<BookDto>>
{
    private readonly IApplicationDbContextFactory _dbContextFactory;

    public AvailableBooksQueryHandler(IApplicationDbContextFactory dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public async Task<IEnumerable<BookDto>> Handle(AvailableBooksQuery request, CancellationToken cancellationToken)
    {
        var dbContext = _dbContextFactory.CreateNewDbContext();

        return dbContext.Books.Select(book=> new BookDto() { Id = book.Id.ToString(), Title = book.Title, Content = book.Content }).ToList();
    }
}