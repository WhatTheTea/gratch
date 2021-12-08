using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using gratch_core;
using System.Reactive.Linq;
using DynamicData;

namespace gratch_desktop.ViewModels
{
    internal class HomeViewModel : BaseViewModel
    {
        private readonly ReadOnlyObservableCollection<Group> groups;
        public ReadOnlyObservableCollection<Group> Groups => groups;
        [Reactive]
        public ObservableCollection<AssigneesItem> Assignees { get; set; }

        public HomeViewModel()
        {
            var service = new Services.GroupService();
            //Groups
            service.Connect()
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .Bind(out groups)
                   .Subscribe();

            UpdateAssignees();
            /*//Assignees /Selected Names
            service.Connect()
                   .TransformMany(group => group
                        .Where(person => person.DutyDates
                            .Contains(DateTime.Today)).Select(person => person.Name))
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .Bind(out ReadOnlyObservableCollection<string> selectednames)
                   .Subscribe();
            //Assignees /Selected Groups
            service.Connect()
                   .Filter(group => group
                        .Where(person => person.DutyDates
                            .Contains(DateTime.Today)).Any())
                   .Transform(group => group.Name)
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .Bind(out ReadOnlyObservableCollection<string> selectedgroups)
                   .Subscribe();*/
            //Update Assignees on Groups Change
            this.WhenAnyValue(x => x.Groups)
                .Subscribe(x => UpdateAssignees());
        }
        private void UpdateAssignees()
        {
            var names = Groups.SelectMany(group => group
                              .Where(person => person.DutyDates
                              .Contains(DateTime.Today))
                              .Select(person => person.Name));
            var groups = Groups.Where(group => group
                               .Where(person => person.DutyDates
                               .Contains(DateTime.Today)).Any())
                               .Select(group => group.Name);

            Assignees = new ObservableCollection<AssigneesItem>(names
                .Zip(groups, (name, group) =>
                new AssigneesItem
                    {
                        Group = group,
                        Name = name
                    }
                ));

        }
    }
}
