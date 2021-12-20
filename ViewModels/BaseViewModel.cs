using DynamicData;

using gratch_core;

using ReactiveUI;

using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace gratch_desktop.ViewModels
{
    public class BaseViewModel : ReactiveObject
    {
        private readonly ReadOnlyObservableCollection<Group> groups;
        internal readonly Services.IGroupService groupService;
        public ReadOnlyObservableCollection<Group> Groups => groups;

        public BaseViewModel()
        {
            //Groups
            groupService = new Services.GroupService();
            groupService.Connect()
                        .Bind(out groups)
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Subscribe();
        }
    }
}
