using System.Collections.Immutable;
using System.ComponentModel;

using DynamicData;

using gratch.Models;
using gratch.Services;

using ReactiveUI;

namespace gratch.app.Services;

/// <summary>
/// Provides access to groups with update notifications
/// </summary>
public interface IGroupManager
{
    SourceCache<Group, string> Groups { get; }

    Task Load();
    Task Save();
}

public class GroupManager(IGroupRepository groupRepository) : ReactiveObject, IGroupManager
{
    private ImmutableArray<Group>? loadSnapshot;

    public SourceCache<Group, string> Groups { get; } = new(x => x.Id);

    public async Task Load()
    {
        var groups = await groupRepository.GetGroupsAsync();
        this.loadSnapshot = groups.ToImmutableArray();
        this.Groups.AddOrUpdate(this.loadSnapshot);
    }

    public Task Save()
    {
        this.Groups.Edit(u => u.Refresh());

        var groupsToRemove = this.loadSnapshot?.Except(this.Groups.Items)
            .Select(x => x.Id)
            .Select(groupRepository.DeleteGroupAsync) ?? [];

        var groupsToUpdate = this.loadSnapshot?.Intersect(this.Groups.Items)
            .Select(groupRepository.UpdateGroupAsync) ?? [];

        return Task.WhenAll([.. groupsToUpdate, .. groupsToRemove]);
    }
}
