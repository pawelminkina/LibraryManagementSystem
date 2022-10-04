using LibraryManagementSystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

        var bookToUpdate = await _dbContext.Books.FirstOrDefaultAsync(s => s.Id == request.BookId, cancellationToken);

        if (bookToUpdate is null)
            throw new ArgumentException($"Book with given id: {request.BookId} does not exist in database");

        bookToUpdate.Title = request.NewTitle;

        //commented for demo purpose, uncomment if you want it to work
        //await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}