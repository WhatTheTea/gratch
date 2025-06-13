using System.Reactive.Linq;

using DynamicData;

using gratch.app.Services;
using gratch.Models;
using gratch.Services;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class DateScheduleViewModel : ReactiveObject
{
    private readonly IArrangementService arrangementService;
    private readonly IGroupManager groupManager;

    [Reactive]
    private DateTime selectedDate = DateTime.Today;

    [Reactive]
    private Dictionary<Group, Person?> arrangements = [];

    public DateScheduleViewModel(IArrangementService arrangementService, IGroupManager groupManager)
    {
        this.arrangementService = arrangementService;
        this.groupManager = groupManager;

        this.WhenAnyValue(x => x.SelectedDate)
            .Subscribe(this.UpdateArrangements);

        this.groupManager.Groups.Connect()
            .OnItemRemoved(group => this.arrangements.Remove(group))
            .WhereReasonsAreNot(ChangeReason.Remove, ChangeReason.Moved)
            .Flatten()
            .Select(x => x.Current)
            .Subscribe(group => this.UpdateArrangementsFor(group, this.SelectedDate));
    }

    private void UpdateArrangements(DateTime current)
    {
        this.arrangements.Clear();

        foreach (var group in this.groupManager.Groups.Items)
        {
            this.UpdateArrangementsFor(group, current);
        }
    }

    private void UpdateArrangementsFor(Group group, DateTime current)
    {
        this.arrangements[group] = this.arrangementService.GetArrangedPersonOn(group, current);
        this.RaisePropertyChanged(nameof(this.Arrangements));
    }
}
