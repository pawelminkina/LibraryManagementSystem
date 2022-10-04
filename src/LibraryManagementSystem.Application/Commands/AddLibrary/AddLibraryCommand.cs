using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Application.Common.Models;
using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Commands.AddLibrary;

public record AddLibraryCommand : IRequest
{
    public AddLibraryCommand(string name, IEnumerable<BookToAddDto> books)
    {
        Books = books;
        Name = name;
    }
    public string? Name { get; set; }
    public IEnumerable<BookToAddDto> Books { get; set; } = Enumerable.Empty<BookToAddDto>();
}

public class AddLibraryCommandHandler : IRequestHandler<AddLibraryCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public AddLibraryCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(AddLibraryCommand request, CancellationToken cancellationToken)
    {
        ValidateRequest(request);

        _dbContext.Libraries.Add(MapToLibraryEntity(request));

        //I can add there as much entities as I want, and after that save changes
        //Thanks to that, it's creating one database transaction even if we're saving not related entities

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private static void ValidateRequest(AddLibraryCommand request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Given name for library is empty");
    }

    private static Library MapToLibraryEntity(AddLibraryCommand command) => new()
    {
        Name = command.Name!,
        Books = command.Books.Select(MapToBookEntity).ToList()
    };

    private static Book MapToBookEntity(BookToAddDto dto) => new()
    {
        Title = dto.Title!
    };
}