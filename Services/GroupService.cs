using DynamicData;

using gratch_core;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace gratch_desktop.Services
{
    internal class GroupService : IGroupService
    {
        private static readonly gratch_core.Models.GroupRepository repository = new();
        static private ObservableCollection<Group> groups;
        /// <summary>
        /// Gets immutable set of all groups
        /// </summary>
        public ReadOnlyObservableCollection<Group> Groups { get => new(groups); }

        static GroupService()
        {
            //Загрузка существующих груп из БД
            groups = new(repository.LoadAllGroups().Cast<Group>());
        }
        //В скором времени надо убрать
        public ObservableCollection<Group> Connect() => groups;

        public void Add(Group group)
        {
            throw new NotImplementedException();
        }

        public void Add(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            var group = this.Get(name);
            this.Remove(group);
        }
        public void Remove(Group group)
        {
            group.Clear();
            groups.Remove(group);
        }
        /// <param name="name">Name of the group, can be found in <see cref="Groups"/></param>
        /// <returns>Single mutable <see cref="Group"/></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Group Get(string name) => groups.First(grp => grp.Name == name);
    }
}
