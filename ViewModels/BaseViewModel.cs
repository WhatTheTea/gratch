using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;

using gratch_core;
using DynamicData;
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
