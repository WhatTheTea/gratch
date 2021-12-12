using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gratch_core;
using DynamicData;
using System.Collections.ObjectModel;

namespace gratch_desktop.Services
{
    internal class GroupService : IGroupService
    {
        private readonly gratch_core.Models.GroupRepository repository = new();
        private readonly SourceList<Group> groups = new();

        public IObservable<IChangeSet<Group>> Connect() => groups.Connect();

        public GroupService()
        {
            //Загрузка существующих груп из БД
            groups.AddRange(repository.LoadAllGroups().Cast<Group>());
        }
    }
}
