using gratch_core;
using System.Linq;
using System;

using ReactiveUI.Fody.Helpers;

namespace gratch_desktop.ViewModels
{
    public class AssigneesItem
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string Group { get; set; }

        public AssigneesItem()
        {
        }

        public AssigneesItem(Group grp)
        {
            Person selectedPerson = grp.Graph.AssignedPeople.FirstOrDefault(p => 
                                                                p.DutyDates.Any(d => d == DateTime.Today));
            Name = selectedPerson.Name;
            Group = grp.Name;
        }
    }
}
