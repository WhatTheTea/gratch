
using gratch_core;

using ReactiveUI;

using Splat;

using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace gratch_desktop.ViewModels
{
    public class PeopleViewModel : BaseViewModel, IRoutableViewModel
    {
        
        private readonly ReactiveCommand<Unit, Unit> addPerson;
        private readonly IGroup _group;
        public string UrlPathSegment => "/groups/people";
        public IScreen HostScreen { get; }
        public IGroup Group { get => _group; }

        public ReactiveCommand<Unit, Unit> AddPerson => addPerson;

        public PeopleViewModel() { }
        public PeopleViewModel(IGroup group, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            _group = group;

            addPerson = ReactiveCommand.CreateFromTask(async () =>
            {
                var name = await Interactions.TextDialog.Handle("Group name: ");
                if (string.IsNullOrWhiteSpace(name)) return;
                if (Group.Any(person => person.Name == name)) return;
                Group.Add(new Person(name));
            });
        }
    }
}
