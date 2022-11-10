using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Repositories;

public interface ILibraryGroupRepository
{
    Task<LibraryGroup> GetGroup(Guid groupId);
}