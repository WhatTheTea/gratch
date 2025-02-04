using System.Collections.ObjectModel;
using System.Threading.Tasks;

using gratch.Models;
using gratch.Services;

using ReactiveUI;

namespace gratch.ViewModels;
public class PeopleViewModel(IGroupRepository groupRepository) : ReactiveObject
{
    public ObservableCollection<Group> Groups { get; } = [];

    public async Task Initialize()
    {
        var groups = await groupRepository.GetGroupsAsync();

        foreach (var item in groups)
        {
            this.Groups.Add(item);
        }
    }
}
