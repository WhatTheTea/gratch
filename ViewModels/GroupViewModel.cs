using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using gratch_core;

using DynamicData;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace gratch_desktop.ViewModels
{
    internal class GroupViewModel : BaseViewModel
    {
        private readonly ReadOnlyObservableCollection<Group> groups;
        public ReadOnlyObservableCollection<Group> Groups => groups;

        public GroupViewModel()
        {
            var service = new Services.GroupService();
            service.Connect()
                   .ObserveOn(RxApp.MainThreadScheduler)
                   .Bind(out groups)
                   .Subscribe();
        }
    }
}
