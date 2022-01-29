using System.Collections.ObjectModel;

using gratch_core;

using System;

namespace gratch_desktop.Services
{
    internal interface IGroupService
    {
        ObservableCollection<Group> Connect();
    }
}