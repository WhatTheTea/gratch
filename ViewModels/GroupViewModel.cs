using gratch_core;

using DynamicData;

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
        private ReactiveCommand<Unit, Unit> addGroup;
        
        public ReadOnlyObservableCollection<GroupItemViewModel> GroupItems;
        public ReactiveCommand<Unit, Unit> AddGroup => addGroup;

        public string UrlPathSegment => "/groups";
        public IScreen HostScreen { get; }

        public GroupViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            // GroupItems
            groupService.Connect()
                .Transform(grp => new GroupItemViewModel(grp, HostScreen))
                .Filter(grp => grp != null)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out GroupItems)
                .DisposeMany()
                .Subscribe();

            addGroup = ReactiveCommand.CreateFromTask(async () =>
            {
                var name = await Interactions.GetTextDialogInteraction("Group name: ");
                //Validation
                if (string.IsNullOrWhiteSpace(name)) return;
                if (groupService.GetByName(name) != default) return;

                groupService.Add(new Group(name));
            });

#if DEBUG
            addGroup.ThrownExceptions.Subscribe();
#endif
        } 
    }
}
