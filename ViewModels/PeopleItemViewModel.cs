using gratch_core;

using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    public class PeopleItemViewModel
    {
        [Reactive]
        public string Name { get; set; }

        public PeopleItemViewModel() { }
        public PeopleItemViewModel(string name)
        {
            Name = name;
        }
        public PeopleItemViewModel(Person person)
        {
            Name = person.Name;
        }
    }
}
