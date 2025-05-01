using System.Reactive.Linq;

using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<ScheduleViewModel>]
public partial class SchedulePage : UserControl
{
    public SchedulePage()
    {
        this.InitializeComponent();
        this.ViewModel = Ioc.Container.GetService<ScheduleViewModel>();

        this.OneWayBind(this.ViewModel, x => x.Groups, x => x.groupsComboBox.DataSource);

        this.groupsComboBox.DisplayMember = "Name";
        this.OneWayBind(this.ViewModel, x => x.SelectedGroup, x => x.groupsComboBox.SelectedItem);
        Observable.FromEventPattern(ev => this.groupsComboBox.SelectedValueChanged += ev, ev => this.groupsComboBox.SelectedValueChanged -= ev)
            .Select(_ => this.groupsComboBox.SelectedItem)
            .BindTo(this.ViewModel, vm => vm.SelectedGroup);

        var now = DateTime.Now;
        var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
        var daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
        var dates = Enumerable.Range(0, daysInMonth)
                  .Select(d => firstDayOfMonth.AddDays(d));
        foreach (var date in dates)
        {
            this.scheduleDataGrid.Columns.Add(date.Day.ToString(), date.Day.ToString());
        }

    }
}
