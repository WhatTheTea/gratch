using gratch_core;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Splat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;


namespace gratch_desktop.ViewModels
{
    public class GroupViewModel : BaseViewModel, IRoutableViewModel
    {
        public ObservableCollection<GroupItem> GroupItems { get; set; }

        public string UrlPathSegment => "/groups";
        public IScreen HostScreen { get; }


        public GroupViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            GroupItems = new ObservableCollection<GroupItem>();
            Groups_CollectionChanged();

            groupService.Connect()
                        .CollectionChanged += Groups_CollectionChanged;


        }

        private void Groups_CollectionChanged(object sender = null, System.Collections.Specialized.NotifyCollectionChangedEventArgs e = null)
        {
            GroupItems.Clear();

            var groupitems = from grp in groupService.Connect()
                             where grp != null
                             select new GroupItem(grp, HostScreen);

            groupitems.ToList().ForEach(item => GroupItems.Add(item));
        }
    }
}
