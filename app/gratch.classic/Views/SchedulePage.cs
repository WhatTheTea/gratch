using System;
using System.Reactive.Linq;

using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<ScheduleViewModel>]
public partial class SchedulePage : UserControl
{
    private static DateTime MonthStart => new(DateTime.Now.Year, DateTime.Now.Month, 1);

    private static int MonthDays => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

    private static IEnumerable<DateTime> MonthDates =>
        Enumerable.Range(0, MonthDays)
            .Select(d => MonthStart.AddDays(d));

    private static readonly DataGridViewCellStyle CurrentDateCellStyle = new()
    {
        BackColor = Color.BlueViolet
    };

    public SchedulePage()
    {
        this.InitializeComponent();
        this.InitializeScheduleDataGrid();
        this.ViewModel = Ioc.Container.GetService<ScheduleViewModel>();
        this.InitializeBindings();
    }

    private void InitializeBindings()
    {
        this.OneWayBind(this.ViewModel, x => x.Groups, x => x.groupsComboBox.DataSource);

        this.groupsComboBox.DisplayMember = "Name";
        this.OneWayBind(this.ViewModel, x => x.SelectedGroup, x => x.groupsComboBox.SelectedItem);
        Observable.FromEventPattern(ev => this.groupsComboBox.SelectedValueChanged += ev, ev => this.groupsComboBox.SelectedValueChanged -= ev)
            .Select(_ => this.groupsComboBox.SelectedItem)
            .BindTo(this.ViewModel, vm => vm.SelectedGroup);

        this.ViewModel.WhenAnyValue(x => x.Arrangement)
            .WhereNotNull()
            .Subscribe(this.UpdateScheduleDataGrid);
    }

    private void InitializeScheduleDataGrid()
    {
        this.scheduleDataGrid.Columns.Add("Name", "Name");
        foreach (var date in MonthDates)
        {
            var columnIndex = this.scheduleDataGrid.Columns.Add(date.Day.ToString(), date.Day.ToString());
            var column = this.scheduleDataGrid.Columns[columnIndex];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = 25;
        }
    }

    private void UpdateScheduleDataGrid(Models.Arrangement arrangement)
    {
        this.scheduleDataGrid.Rows.Clear();

        foreach (var person in this.ViewModel?.SelectedGroup?.People ?? [])
        {
            var name = person.Name;
            var rowIndex = this.scheduleDataGrid.Rows.Add(name);

            var arrangedDays = MonthDates.Where(x => person == arrangement[x])
                .Select(x => x.Day.ToString());

            foreach (var day in arrangedDays)
            {
                this.scheduleDataGrid[day, rowIndex].Style = CurrentDateCellStyle;
            }
        }
    }
}
