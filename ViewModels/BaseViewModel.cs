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
        internal readonly Services.GroupService groupService;

        public BaseViewModel()
        {
            //Groups
            groupService = new Services.GroupService();
        }
    }
}
