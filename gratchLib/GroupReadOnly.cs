using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib
{
    public class GroupReadOnly : Group
    {
        private static readonly List<GroupReadOnly> instances = new();
        private readonly Group _original;

        public override string Name
        {
            get => _original.Name;
            set => throw new NotSupportedException();
        }

        public override IList<Person> People => _original.People;
        public override IList<Person> ActivePeople => _original.ActivePeople;

        public override Calendar Calendar => _original.Calendar;

        public override void AddPerson(string name) => throw new NotSupportedException();

        public override void RemovePerson(Person person) => throw new NotSupportedException();

        public override void AssignTo(ISchedule schedule)
        {
            _original.AssignTo(schedule); // this method shouldn't change group's behaviour
        }

        public override bool Contains(string name)
        {
            return _original.Contains(name);
        }

        private GroupReadOnly(Group original)
        {
            _original = original;

            instances.Add(this);
        }

        public static GroupReadOnly Get(Group group)
        {
            GroupReadOnly? instance = instances.FirstOrDefault(ro => ro._original == group);

            if (instance == null)
            {
                return new GroupReadOnly(group);
            }
            else
            {
                return instance;
            }
        }
    }
}
