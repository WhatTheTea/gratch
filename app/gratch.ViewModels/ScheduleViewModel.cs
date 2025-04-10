using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using DynamicData;

using gratch.app.Services;
using gratch.Models;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class ScheduleViewModel : ReactiveObject
{
    private readonly IScheduler uiScheduler;

    [Reactive]
    private Group? selectedGroup;

    public BindingList<Group> Groups { get; } = [];

    public ScheduleViewModel(IGroupManager groupManager, IScheduler? uiScheduler = null)
    {
        this.uiScheduler = uiScheduler ?? RxApp.MainThreadScheduler;
        var changeSet = groupManager.Groups.Connect();

        changeSet
            .ObserveOn(this.uiScheduler)
            .Bind(this.Groups)
            .Subscribe(x => Debug.Print($"updates {x.Updates}"));

        changeSet
            .ObserveOn(this.uiScheduler)
            .Take(1)
            .Subscribe(x => this.SelectedGroup = x.First().Current);
    }
}
