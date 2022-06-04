using DynamicData;

using gratch_core;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace gratch_desktop.Services
{
    //TODO: Сделать из этого Singleton
    internal class GroupService : IGroupService
    {
        private static readonly gratch_core.Models.GroupRepository repository = new();
        private static readonly SourceList<Group> groups;
        /// <summary>
        /// Gets immutable set of all groups
        /// </summary>

        //public ReadOnlyObservableCollection<Group> Groups { get => new(groups); }

        public IObservable<IChangeSet<Group>> Connect(Func<Group,bool> predicate = null) => groups.Connect(predicate);

        static GroupService()
        {
            //Загрузка существующих груп из БД
            //groups = new(repository.LoadAllGroups().Cast<Group>());
            groups = new SourceList<Group>();
            groups.AddRange(repository.LoadAllGroups().Cast<Group>());
        }

        public void Add(Group group)
        {
            groups.Add(group);
        }
        public void Remove(Group group)
        {
            if (group.Count > 0) group.Clear();
            groups.Remove(group);
        }

        /// <param name="name">Name of the group, can be found in <see cref="Connect()"/></param>
        /// <returns>Single mutable <see cref="Group"/></returns>
        public Group GetByName(string name)
        {
            return groups.Items.FirstOrDefault(x => x.Name == name);
        }
    }
}
