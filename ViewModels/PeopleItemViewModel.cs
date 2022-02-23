using gratch_core;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace gratch_desktop.ViewModels
{
    public class PeopleItemViewModel : BaseViewModel
    {
        [Reactive]
        public string Name { get; set; }
        public ICommand DeleteCommand { get; set; }
        private readonly Group ownerGroup;
        private readonly Person person;

        public PeopleItemViewModel()
        {
            DeleteCommand = ReactiveCommand.Create(() =>
            {
                ownerGroup.Remove(person);
                return;
            });
        }
        public PeopleItemViewModel(string name, string groupname) : this()
        {
            ownerGroup = groupService.Get(groupname);
            person = ownerGroup.First(p => p.Name == name);
            Name = person.Name;
        }
        public PeopleItemViewModel(Person person, Group grp) : this()
        {
            Name = person.Name;
            this.person = person;
            ownerGroup = grp;
        }
    }
}
