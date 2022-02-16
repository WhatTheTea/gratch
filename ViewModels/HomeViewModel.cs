using DynamicData;

using ReactiveUI;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace gratch_desktop.ViewModels
{
    public class HomeViewModel : BaseViewModel, IRoutableViewModel
    {
        public ObservableCollection<AssigneesItem> Assignees => assignees;
        private readonly ObservableCollection<AssigneesItem> assignees = new();
        public string UrlPathSegment => "/home";

        public IScreen HostScreen { get; }

        public HomeViewModel(IScreen screen = null)
        {
            HostScreen = screen;

            groupService.Connect().CollectionChanged += Groups_CollectionChanged;
            Groups_CollectionChanged();
            //Assignees
            /*groupService.Connect()
                        .Transform(x => new AssigneesItem(x))
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Bind(out assignees)
                        .DisposeMany()
                        .Subscribe();
            */

        }

        private void Groups_CollectionChanged(object sender = null, System.Collections.Specialized.NotifyCollectionChangedEventArgs e = null)
        {
            assignees.Clear();

            var groupitems = from grp in groupService.Connect()
                             where grp != null
                             select new AssigneesItem(grp);

            groupitems.ToList().ForEach(item => assignees.Add(item));
        }
    }
}
