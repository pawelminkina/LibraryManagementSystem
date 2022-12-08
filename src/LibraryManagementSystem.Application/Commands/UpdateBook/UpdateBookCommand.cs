using System.Runtime.CompilerServices;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using MediatR;
[assembly: InternalsVisibleTo("LibraryManagementSystem.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]


namespace LibraryManagementSystem.Application.Commands.UpdateBook;

public record UpdateBookCommand : IRequest
{
    public UpdateBookCommand(Guid bookId, string newTitle)
    {
        BookId = bookId;
        NewTitle = newTitle;
    }

    public Guid BookId { get; set; }
    public string NewTitle { get; set; }
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateBookCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.NewTitle))
            throw new ArgumentException("Given title for book is empty");

        var bookToUpdate = await GetBookToUpdate(request.BookId, cancellationToken);

        bookToUpdate.Title = request.NewTitle;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    internal Task<Book> GetBookToUpdate(Guid bookId, CancellationToken ct)
    {
        var bookToUpdate = _dbContext.Books.FirstOrDefault(s => s.Id == bookId);

        if (bookToUpdate is null)
            throw new ArgumentException($"Book with given id: {bookId} does not exist in database");

        return Task.FromResult(bookToUpdate);
    }
}