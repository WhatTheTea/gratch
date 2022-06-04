
using gratch_core;

using ReactiveUI;

using Splat;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Security.Cryptography;

namespace gratch_desktop.ViewModels
{
    public class PeopleViewModel : BaseViewModel, IRoutableViewModel
    {
        private readonly ObservableCollection<PeopleItemViewModel> people = new();
        private readonly ReactiveCommand<Unit, Unit> addPerson;
        private readonly Group _group;
        public string UrlPathSegment => "/groups/people";
        public IScreen HostScreen { get; }
        public Group Group { get => _group; }

        public ObservableCollection<PeopleItemViewModel> People => people;
        public ReactiveCommand<Unit, Unit> AddPerson => addPerson;


        public PeopleViewModel() { }
        public PeopleViewModel(Group group, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _group = group;

            Group.PersonAdded += PeopleChanged;
            Group.PersonChanged += PeopleChanged;
            Group.PersonRemoved += PeopleChanged;
            PeopleChanged();

            addPerson = ReactiveCommand.CreateFromTask(async () =>
            {
                var name = await Interactions.GetTextDialogInteraction("Name: ");
                if (string.IsNullOrWhiteSpace(name)) return;
                if (Group.Any(person => person.Name == name)) return;
                Group.Add(name);
            });
#if DEBUG
            addPerson.ThrownExceptions.Subscribe();
#endif
        }

        private void PeopleChanged(object sender = null, IPerson person = null)
        {
            people.Clear();

            var peoplevm = from p in _group
                           select new PeopleItemViewModel(p, Group);

            foreach(var p in peoplevm)
            {
                people.Add(p);
            }
        }
    }
}
