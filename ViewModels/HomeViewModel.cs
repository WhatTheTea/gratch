using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using gratch_core;
using DynamicData;

namespace gratch_desktop.ViewModels
{
    internal class HomeViewModel : BaseViewModel
    {
        [Reactive]
        public ObservableCollection<AssigneesItem> Assignees { get; set; }

        public HomeViewModel()
        {
            var itemsCreator = new AssigneesItemsCreator();
            Assignees = itemsCreator.Create();
        }
    }
}
