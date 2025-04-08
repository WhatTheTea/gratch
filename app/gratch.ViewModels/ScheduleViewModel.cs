using System.ComponentModel;

using DynamicData;

using gratch.Models;
using gratch.Services;

using ReactiveUI;

namespace gratch.ViewModels;
public class ScheduleViewModel(IGroupRepository groupRepository) : ReactiveObject
{
    public BindingList<Group> Groups { get; } = [];

    public async Task Initialize()
    {
        var groups = await groupRepository.GetGroupsAsync();
        this.Groups.Add(groups);
    }
}
