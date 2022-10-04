using LibraryManagementSystem.Application.Commands.AddLibrary;
using LibraryManagementSystem.Application.Common.Models;
using LibraryManagementSystem.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Tests.Integration.Application.Commands.AddLibrary;

public class AddLibraryCommandHandlerTests
{
    [Test]
    public async Task LibraryPassesRequirements_ItsAddedToDatabase()
    {
        //GIVEN library to add
        var libraryToAdd = new AddLibraryCommand("new library", new[]
        {
            new BookToAddDto() { Title = "title1" },
            new BookToAddDto() { Title = "title2" },
            new BookToAddDto() { Title = "title3" },
        });

        //WHEN service under test is created
        var dbContextName = Guid.NewGuid().ToString();
        var dbContext = CreateDb(dbContextName);

        var sut = new AddLibraryCommandHandler(dbContext);

        //AND handle is called in it with library to add
        await sut.Handle(libraryToAdd, CancellationToken.None);

        //THEN check whether added library is the only one in database
        var newDbContext = CreateDb(dbContextName);
        newDbContext.Libraries.Should().HaveCount(1);

        //AND those it have books added
        var library = newDbContext.Libraries.Include(s=>s.Books).First();
        library.Books.Should().HaveCount(3);
        library.Books.Should().Contain(s => s.Title == "title1");
        library.Books.Should().Contain(s => s.Title == "title2");
        library.Books.Should().Contain(s => s.Title == "title3");
    }

    private static ApplicationDbContext CreateDb(string databaseName)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(databaseName: databaseName).Options;
        var context = new ApplicationDbContext(options, null!);
        return context;
    }
}