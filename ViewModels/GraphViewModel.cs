
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Splat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData;
using System.Linq;

namespace gratch_desktop.ViewModels
{
    public class GraphViewModel : BaseViewModel, IRoutableViewModel
    {
        public string UrlPathSegment => "/graph";
        public IScreen HostScreen { get; }
        public ObservableCollection<AssigneesItemViewModel> Assignees { get; set; }

        [Reactive]
        public bool FlyoutIsOpen { get; set; }
        //Calendar
        [Reactive]
        public DateTime? SelectedCalendarDate { get; set; }
        public DateTime CalendarStartDate => new(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime CalendarEndDate => new(DateTime.Now.Year, DateTime.Now.Month,
            DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));


        public GraphViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            SelectedCalendarDate = null;
            Assignees = new();

            this.WhenAnyValue(x => x.SelectedCalendarDate)
                .Subscribe(x =>
                {
                    if (SelectedCalendarDate != null || SelectedCalendarDate != default)
                    {
                        FlyoutIsOpen = false;
                        Assignees.Clear();

                        foreach (var grp in groupService.Groups)
                        {
                            if (grp.Any())
                            {
                                Assignees.Add(new AssigneesItemViewModel(grp, x.Value));
                            }
                        }

                        FlyoutIsOpen = true;
                    }
                });
        }
    }
}
