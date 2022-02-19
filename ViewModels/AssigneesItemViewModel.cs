using gratch_core;

using ReactiveUI.Fody.Helpers;

using System;
using System.Linq;

namespace gratch_desktop.ViewModels
{
    public class AssigneesItemViewModel
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string Group { get; set; }
        [Reactive]
        public DateTime Date { get; set; }

        public AssigneesItemViewModel()
        {
        }

        public AssigneesItemViewModel(Group grp, DateTime? date = null)
        {
            Date = date ?? DateTime.Today;
            Person selectedPerson = grp.First(p => p.DutyDates.Any(d => d == Date));
            Name = selectedPerson.Name;
            Group = grp.Name;
        }
    }
}
