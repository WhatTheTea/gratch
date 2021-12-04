using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace gratch_desktop.ViewModels
{
    internal class GraphViewModel : BaseViewModel
    {
        [Reactive]
        public bool FlyoutIsOpen { get; set; }
        [Reactive]
        public DateTime LastCalendarDate { get; set; }
        public ReactiveCommand<DateTime,Unit> CalendarDayCommand { get; }
        public DateTime CalendarStartDate => new(DateTime.Now.Year,DateTime.Now.Month,1);
        public DateTime CalendarEndDate => new(DateTime.Now.Year, DateTime.Now.Month,
            DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        public GraphViewModel()
        {
            CalendarDayCommand = ReactiveCommand.Create<DateTime, Unit>(date =>
             {
                 if (date != default)
                 {
                     FlyoutIsOpen = false;
                     LastCalendarDate = date;
                     FlyoutIsOpen = true;
                 }
                 return default;
             });
        }
    }
}
