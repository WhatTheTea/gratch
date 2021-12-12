using DynamicData;

using gratch_core;

using System;

namespace gratch_desktop.Services
{
    internal interface IGroupService
    {
        IObservable<IChangeSet<Group>> Connect();
    }
}