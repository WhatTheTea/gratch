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
        //private readonly SourceList<Group> groups = new();

        static private ObservableCollection<Group> Groups { get; }

        

        static GroupService()
        {
            //Загрузка существующих груп из БД
            Groups = new(repository.LoadAllGroups().Cast<Group>());
        }

        public ObservableCollection<Group> Connect() => Groups;
    }
}
