using gratch.Models;

namespace gratch.Services;
public class InMemoryGroupRepository : IGroupRepository
{
    private readonly Dictionary<string, Group> groups = [];

    public Task<Group> CreateGroupAsync(string name)
    {
        var group = new Group { Name = name, BaseDateTimeOffset = DateTimeOffset.Now, Id = Guid.NewGuid().ToString() };
        this.groups[group.Id] = group;

        return Task.FromResult(group);
    }
    public Task DeleteGroupAsync(string id)
    {
        this.groups.Remove(id);
        return Task.CompletedTask;
    }

    public Task<Group?> GetGroupAsync(string id)
    {
        this.groups.TryGetValue(id, out var group);
        return Task.FromResult(group);
    }

    public Task<Group[]> GetGroupsAsync() => Task.FromResult(this.groups.Values.ToArray());

    public Task UpdateGroupAsync(Group group)
    {
        if (this.groups.ContainsKey(group.Id))
        {
            this.groups[group.Id] = group;
        }
        else
        {
            throw new InvalidOperationException("Trying to update group that does not exist yet");
        }

        return Task.CompletedTask;
    }
}
