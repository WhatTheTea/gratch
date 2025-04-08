using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;

using DynamicData;

using gratch.Models;
using gratch.Services;

using ReactiveUI;

namespace gratch.app.Services;

public class GroupManager(IGroupRepository groupRepository) : ReactiveObject
{
    private ImmutableArray<Group>? loadSnapshot;

    public BindingList<Group> Groups { get; }

    public async Task Load()
    {
        var groups = await groupRepository.GetGroupsAsync();
        loadSnapshot = groups.ToImmutableArray();
        this.Groups.Add(groups);
    }

    public Task Save()
    {
        var groupsToUpdate = this.loadSnapshot?.Intersect(this.Groups)
            .Select(groupRepository.UpdateGroupAsync) ?? [];

        var groupsToRemove = this.loadSnapshot?.Except(this.Groups)
            .Select(x => x.Id)
            .Select(groupRepository.DeleteGroupAsync) ?? [];

        return Task.WhenAll([.. groupsToUpdate, .. groupsToRemove]);
    }
}
