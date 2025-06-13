using System.ComponentModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using DynamicData;

using gratch.app.Services;
using gratch.Models;
using gratch.Services;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class GroupScheduleViewModel : ReactiveObject
{
    private readonly IArrangementService arrangementService;
    private readonly IScheduler uiScheduler;

    [Reactive]
    private Models.Arrangement? arrangement;

    [Reactive]
    private Group? selectedGroup;

    public BindingList<Group> Groups { get; } = [];

    public GroupScheduleViewModel(IGroupManager groupManager, IArrangementService arrangementService, IScheduler? uiScheduler = null)
    {
        this.arrangementService = arrangementService;
        this.uiScheduler = uiScheduler ?? RxApp.MainThreadScheduler;
        var changeSet = groupManager.Groups.Connect();

        changeSet
            .ObserveOn(this.uiScheduler)
            .Bind(this.Groups)
            .Subscribe();

        changeSet
            .ObserveOn(this.uiScheduler)
            .Take(1)
            .Subscribe(x => this.SelectedGroup = x.First().Current);

        this.WhenAnyValue(x => x.SelectedGroup)
            .WhereNotNull()
            .Subscribe(this.UpdateArrangement);

        changeSet.Filter(x => x.Id == this.SelectedGroup?.Id, false)
            .Select(x => this.SelectedGroup)
            .WhereNotNull()
            .Subscribe(this.UpdateArrangement);
    }

    private void UpdateArrangement(Group group)
    {
        var now = DateTime.Now;
        var monthStart = new DateTime(now.Year, now.Month, 1);
        var monthEnd = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

        this.Arrangement = this.arrangementService.GetArrangementFor(group, monthStart, monthEnd);
    }
}
