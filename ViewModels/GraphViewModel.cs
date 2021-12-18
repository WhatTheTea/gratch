using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Splat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gratch_desktop.ViewModels
{
    public class GraphViewModel : BaseViewModel, IRoutableViewModel
    {
        public string UrlPathSegment => "Graph";
        public IScreen HostScreen { get; }


        [Reactive]
        public ObservableCollection<AssigneesItem> Assignees { get; set; }
        [Reactive]
        public bool FlyoutIsOpen { get; set; }
        //Calendar
        [Reactive]
        public DateTime LastCalendarDate { get; set; }
        public ReactiveCommand<DateTime, Unit> CalendarDayCommand { get; }
        public DateTime CalendarStartDate => new(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime CalendarEndDate => new(DateTime.Now.Year, DateTime.Now.Month,
            DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));


        public GraphViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            CalendarDayCommand = ReactiveCommand.Create<DateTime>(date =>
             {
                 if (date != default)
                 {
                     FlyoutIsOpen = false;
                     LastCalendarDate = date;
                     FlyoutIsOpen = true;
                 }
             });

            var itemsCreator = new AssigneesItemsCreator();
            this.WhenAnyValue(x => x.LastCalendarDate)
                .Subscribe(x =>
                {
                    itemsCreator.AssignedOn = LastCalendarDate;
                    Assignees = new ObservableCollection<AssigneesItem>(itemsCreator.Create());
                });
        }
    }
}
