using DynamicData;

using ReactiveUI;

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace gratch_desktop.ViewModels
{
    public class HomeViewModel : BaseViewModel, IRoutableViewModel
    {
        public ReadOnlyObservableCollection<AssigneesItemViewModel> Assignees;
        public string UrlPathSegment => "/home";

        public IScreen HostScreen { get; }

        public HomeViewModel(IScreen screen = null)
        {
            HostScreen = screen;

            groupService.Connect()
                        .Transform(grp => new AssigneesItemViewModel(grp))
                        .ObserveOnDispatcher()
                        .Bind(out Assignees)
                        .DisposeMany()
                        .Subscribe();
        }
    }
}
