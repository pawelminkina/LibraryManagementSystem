using LibraryManagementSystem.Application.Commands.UpdateBook;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Tests.Helpers;

namespace LibraryManagementSystem.Tests.Unit.Application.Commands.UpdateBook;

public class GetBookToUpdateTests
{

    [Test]
    public async Task DbContextHasRequestedBook_ReturnsIt()
    {
        //Arrange 
        var dbContext = Substitute.For<IApplicationDbContext>();

        //Setting return for property in DbContext using helper
        var expectedBook = GetExpectedBook();
        var books = new List<Book>() { expectedBook }.AsQueryable();
        var dbSetBooks = DbContextHelpers.CreateMockedDbSet(books);
        dbContext.Books.Returns(dbSetBooks);

        var sut = new UpdateBookCommandHandler(dbContext);

        //Act
        var actual = await sut.GetBookToUpdate(expectedBook.Id, CancellationToken.None);

        //Assert
        actual.Should().BeEquivalentTo(expectedBook);
    }

    [Test]
    public async Task DbContextHasNoRequestedBook_ThrowsException()
    {
        //Arrange 
        var expectedBookId = Guid.NewGuid();
        var dbContext = Substitute.For<IApplicationDbContext>();

        //Setting return for property in DbContext using helper
        var books = new List<Book>().AsQueryable();
        var dbSetBooks = DbContextHelpers.CreateMockedDbSet(books);
        dbContext.Books.Returns(dbSetBooks);

        var sut = new UpdateBookCommandHandler(dbContext);

        //Act
        var actual = async () => { await sut.GetBookToUpdate(expectedBookId, CancellationToken.None); };
        
        //Assert
        await actual.Should().ThrowAsync<ArgumentException>();
    }

    private static Book GetExpectedBook() => new() { Id = Guid.NewGuid(), Title = "Expected title", LibraryId = Guid.NewGuid()};
}