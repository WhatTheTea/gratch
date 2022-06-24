using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib
{
    public class GroupReadOnly : IGroup
    {
        private IGroup _original;

        public string Name { 
            get => _original.Name; 
            set => throw new NotSupportedException(); 
        }

        public IList<IPerson> People => _original.People;

        public ICalendar Calendar => _original.Calendar;

        public void AddPerson(string name)
        {
            throw new NotSupportedException();
        }

        public void RemovePerson(IPerson person)
        {
            throw new NotSupportedException();
        }
        public GroupReadOnly(IGroup original)
        {
            _original = original;
        }
    }
}
