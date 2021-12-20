using DynamicData;

using ReactiveUI;

using Splat;

using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace gratch_desktop.ViewModels
{
    public class GroupViewModel : BaseViewModel, IRoutableViewModel
    {
        public ReadOnlyObservableCollection<GroupItem> GroupItems => groupItems;
        private readonly ReadOnlyObservableCollection<GroupItem> groupItems;

        public string UrlPathSegment => "/groups";
        public IScreen HostScreen { get; }

        public GroupViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            groupService.Connect()
                        .Transform(x => new GroupItem(x))
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Bind(out groupItems)
                        .DisposeMany()
                        .Subscribe();
        }

    }
}
