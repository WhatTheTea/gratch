using gratch_core;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Splat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;


namespace gratch_desktop.ViewModels
{
    public class GroupViewModel : BaseViewModel, IRoutableViewModel
    {
        private ObservableCollection<GroupItemViewModel> groupItems;
        private ReactiveCommand<Unit, Unit> addGroup;

        public ObservableCollection<GroupItemViewModel> GroupItems => groupItems;
        public ReactiveCommand<Unit, Unit> AddGroup => addGroup;

        public string UrlPathSegment => "/groups";
        public IScreen HostScreen { get; }

        public GroupViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var groups = groupService.Groups;

            groupItems = new();
            Groups_CollectionChanged();
            ((INotifyCollectionChanged)groups).CollectionChanged += Groups_CollectionChanged;

            addGroup = ReactiveCommand.CreateFromTask(async () =>
            {
                var name = await Interactions.TextDialog.Handle(new("Group name: "));
                //Validation
                if (string.IsNullOrWhiteSpace(name)) return;
                if (groups.Any(grp => grp.Name == name)) return;

                groupService.Add(new Group(name));
            });
#if DEBUG
            addGroup.ThrownExceptions.Subscribe();
#endif
        }

 

        private void Groups_CollectionChanged(object sender = null, System.Collections.Specialized.NotifyCollectionChangedEventArgs e = null)
        {
            groupItems.Clear();

            var groupitems = from grp in groupService.Groups
                             where grp != null
                             select new GroupItemViewModel(grp, HostScreen);

            groupitems.ToList().ForEach(item => groupItems.Add(item));
        }
    }
}
