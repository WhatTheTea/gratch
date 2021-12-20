using gratch_desktop.ViewModels;

using ReactiveUI;

using System.Reactive.Disposables;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для GraphView.xaml
    /// </summary>
    public partial class GraphView : ReactiveUserControl<GraphViewModel>
    {
        public GraphView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                // StartDate
                this.OneWayBind(ViewModel,
                                vm => vm.CalendarStartDate,
                                vw => vw.GraphCalendar.DisplayDateStart)
                    .DisposeWith(disposables);
                // EndDate
                this.OneWayBind(ViewModel,
                                vm => vm.CalendarEndDate,
                                vw => vw.GraphCalendar.DisplayDateEnd)
                    .DisposeWith(disposables);
                // DateChangedCommand
                this.BindCommand(ViewModel,
                                 vm => vm.CalendarDayCommand,
                                 vw => vw.Calendar_SelectedDateChanged)
                    .DisposeWith(disposables);
                // Flyout is Open
                this.Bind(ViewModel,
                          vm => vm.FlyoutIsOpen,
                          vw => vw.FlyoutAssignees.IsOpen)
                    .DisposeWith(disposables);
                // Flyout header
                this.Bind(ViewModel,
                          vm => vm.SelectedCalendarDate,
                          vw => vw.FlyoutAssignees.Header)
                    .DisposeWith(disposables);
                // List
                this.OneWayBind(ViewModel,
                                vm => vm.Assignees,
                                vw => vw.AssigneesList.ItemsSource)
                    .DisposeWith(disposables);
            });
        }
    }
}
