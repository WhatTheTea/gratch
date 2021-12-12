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
        [Reactive]
        public ObservableCollection<GroupItem> GroupItems { get; set; } = new();
        public GroupViewModel()
        {
            var itemCreator = new GroupItemCreator();
            foreach(var grp in Groups)
            {
                itemCreator.SelectedGroup = grp;
                GroupItems.Add(itemCreator.Create());
            }
        }

    }
}
