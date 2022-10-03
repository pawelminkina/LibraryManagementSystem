namespace LibraryManagementSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContextFactory
    {
        IApplicationDbContext CreateNewDbContext();
    }
}
