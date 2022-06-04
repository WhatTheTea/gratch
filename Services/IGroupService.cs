using System.Collections.ObjectModel;

using gratch_core;

using System;

namespace gratch_desktop.Services
{
    internal interface IGroupService
    {
        void Add(Group group);
        //void Add(string name);
        //void Remove(string name);
        void Remove(Group group);
    }
}