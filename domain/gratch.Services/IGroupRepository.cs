using gratch.Models;

namespace gratch.Services;

/// <summary>
/// Encapsulates people storage method
/// </summary>
public interface IGroupRepository
{
    Task<Group[]> GetGroupsAsync();

    Task<Group?> GetGroupAsync(string id);

    Task<Group> CreateGroupAsync(string name);

    Task UpdateGroupAsync(Group group);

    Task DeleteGroupAsync(string id);
}
