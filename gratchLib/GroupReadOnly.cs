using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib
{
    public static class GroupReadOnly
    {
        private static readonly List<GroupReadOnlyWrapper> instances = new();
        /// <returns>ReadOnlyWrapper of <see cref="Group"/></returns>
        public static Group AsReadOnly(this Group group)
        {
                GroupReadOnlyWrapper? instance = instances.FirstOrDefault(ro => ro._original == group);

                if (instance == null)
                {
                    return new GroupReadOnlyWrapper(group);
                }
                else
                {
                    return instance;
                }
        }

        private sealed class GroupReadOnlyWrapper : Group
        {
            public readonly Group _original;

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

            public override void AssignTo(Schedule schedule)
            {
                _original.AssignTo(schedule); // this method shouldn't change group's behaviour
            }

            public override bool Contains(string name)
            {
                return _original.Contains(name);
            }

            public GroupReadOnlyWrapper(Group original)
            {
                _original = original;

                GroupReadOnly.instances.Add(this);
            }
        }
        
    }
}
