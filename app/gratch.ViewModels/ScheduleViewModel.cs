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
public partial class ScheduleViewModel : ReactiveObject
{
    private readonly IArrangementService arrangementService;
    private readonly IScheduler uiScheduler;

    private Group? selectedGroup;

    [Reactive]
    private Models.Arrangement arrangement;

    public BindingList<Group> Groups { get; } = [];

    public Group? SelectedGroup
    {
        get => this.selectedGroup;
        set
        {
            if (this.RaiseAndSetIfChanged(ref this.selectedGroup, value) is not null)
            {
                var now = DateTimeOffset.Now;
                var monthStart = new DateTimeOffset(now.Year, now.Month, 1, 0, 0, 0, now.Offset);
                var monthEnd = new DateTimeOffset(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month), 0, 0, 0, now.Offset);

                this.Arrangement = this.arrangementService.GetArrangementFor(value!, monthStart, monthEnd);
            }
        }
    }

    public ScheduleViewModel(IGroupManager groupManager, IArrangementService arrangementService, IScheduler? uiScheduler = null)
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
    }
}
