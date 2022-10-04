using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Tests.Helpers;

public static class DbContextHelpers
{
    public static DbSet<T> CreateMockedDbSet<T>(IEnumerable<T> items) where T : class
    {
        var itemsAsQueryable = items.AsQueryable();
        var mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();

        // And then as you do:
        ((IQueryable<T>)mockSet).Provider.Returns(itemsAsQueryable.Provider);
        ((IQueryable<T>)mockSet).Expression.Returns(itemsAsQueryable.Expression);
        ((IQueryable<T>)mockSet).ElementType.Returns(itemsAsQueryable.ElementType);
        ((IQueryable<T>)mockSet).GetEnumerator().Returns(itemsAsQueryable.GetEnumerator());

        return mockSet;
    }
}