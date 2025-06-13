using System.Reactive.Linq;

using DynamicData.Binding;

using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<DateScheduleViewModel>]
public partial class HomePage : UserControl
{
    public HomePage()
    {
        this.InitializeComponent();
        this.ViewModel = Ioc.Container.GetService<DateScheduleViewModel>();

        Observable.FromEventPattern<DateRangeEventHandler, DateRangeEventArgs>(h => this.calendar.DateSelected += h, h => this.calendar.DateSelected -= h)
            .Select(x => x.EventArgs.Start)
            .BindTo(this.ViewModel, x => x.SelectedDate);

        this.ViewModel!.WhenPropertyChanged(x => x.Arrangements)
            .Select(x => x.Value)
            .Subscribe(arrangements =>
            {
                this.scheduleListView.BeginUpdate();
                this.scheduleListView.Items.Clear();
                this.scheduleListView.Groups.Clear();

                foreach ((var group, var person) in arrangements?.Where(kv => kv.Value is not null) ?? [])
                {
                    var visualGroup = new ListViewGroup(group.Name);
                    this.scheduleListView.Groups.Add(visualGroup);

                    var visualPerson = this.scheduleListView.Items.Add(new ListViewItem { Text = person!.Name, Group = visualGroup });
                }
                this.scheduleListView.EndUpdate();
            });
    }
}
