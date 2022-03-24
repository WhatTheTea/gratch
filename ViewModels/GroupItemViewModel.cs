using gratch_core;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace gratch_desktop.ViewModels
{
    public class GroupItemViewModel
    {
        private readonly Group selectedGroup;

        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string Holidays { get; set; }
        public ICommand ClickCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RenameCommand { get; set; }
        public ICommand HolidaysCommand { get; set; }

        private List<DateTime> holidays
        {
            get
            {
                List<DateTime> result = null;
                var now = DateTime.Now;
                int holidaysCount = selectedGroup.Graph.Weekend.Count;

                for (int i = 1, d = 1; i <= DateTime.Now.DaysInMonth() || d <= holidaysCount; i++)
                {
                    var date = new DateTime(now.Year, now.Month, i);
                    if (selectedGroup.Graph.IsHoliday(date))
                    {
                        result.Add(date);
                    }
                }

                return result;

            }
        }
        public GroupItemViewModel()
        {
        }
        public GroupItemViewModel(Group grp, IScreen screen)
        {
            selectedGroup = grp;
            Name = grp.Name;
            var grpService = new Services.GroupService();
            //Holidays
            if (holidays != null)
            {
                string holidaysResult = "Holidays: ";
                foreach (var day in holidays)
                {
                    // Вставка запятой
                    holidaysResult += (day != holidays.Last()) ? $@"{day:ddd}, " : $@"{day:ddd}";
                }
                Holidays = holidaysResult;
            }
            else
            {
                Holidays = "Holidays: None";
            }
            //Commands
            ClickCommand = ReactiveCommand.Create(() =>
                screen.Router.Navigate.Execute(
                    new PeopleViewModel(selectedGroup, screen)));
            DeleteCommand = ReactiveCommand.Create(() => 
                grpService.Remove(selectedGroup));

            RenameCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var name = await Interactions.TextDialog.Handle(new("New group name: "));
                //Validation
                if (string.IsNullOrWhiteSpace(name)) return;
                if (grpService.Groups.Any(grp => grp.Name == name)) return;

                grp.Name = name;
            });
#if DEBUG
            (RenameCommand as ReactiveCommand<Unit, Unit>).ThrownExceptions.Subscribe();
#endif
        }

    }
}
