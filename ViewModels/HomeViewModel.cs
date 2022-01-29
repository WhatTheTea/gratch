using DynamicData;

using ReactiveUI;

using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace gratch_desktop.ViewModels
{
    public class HomeViewModel : BaseViewModel, IRoutableViewModel
    {
        public ReadOnlyObservableCollection<AssigneesItem> Assignees => assignees;
        private readonly ReadOnlyObservableCollection<AssigneesItem> assignees;
        public string UrlPathSegment => "/home";

        public IScreen HostScreen { get; }

        public HomeViewModel(IScreen screen = null)
        {
            HostScreen = screen;

            //Assignees
            /*groupService.Connect()
                        .Transform(x => new AssigneesItem(x))
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Bind(out assignees)
                        .DisposeMany()
                        .Subscribe();
            */

        }
    }
}
