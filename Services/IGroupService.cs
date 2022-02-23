using System.Collections.ObjectModel;

using gratch_core;

using System;

namespace gratch_desktop.Services
{
    internal interface IGroupService
    {
        //ObservableCollection<Group> Connect();
        void Add(Group group);
        void Add(string name);
        void Remove(string name);
        void Remove(Group group);
        Group Get(string name);
        //ReadOnlyObservableCollection<Group> Groups { get; }
    }
}