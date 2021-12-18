using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    internal class AssigneesItemsCreator : BaseItemCreator<List<AssigneesItem>>
    {
        private IEnumerable<string> names;
        private IEnumerable<string> groupnames;

        private DateTime assignedOn = DateTime.Today;
        public DateTime AssignedOn
        {
            get
            {
                return assignedOn;
            }
            set
            {
                assignedOn = value;
            }
        }

        public override List<AssigneesItem> Create()
        {
            names = Groups.SelectMany(group => group
                                .Where(person => person.DutyDates
                                .Contains(AssignedOn))
                              .Select(person => person.Name));
            groupnames = Groups.Where(group => group
                                .Where(person => person.DutyDates
                                .Contains(AssignedOn))
                                .Any())
                               .Select(group => group.Name);

            var result = new List<AssigneesItem>(names
                .Zip(groupnames, (name, group) =>
                new AssigneesItem
                {
                    Group = group,
                    Name = name
                }
                ));
            return result;
        }
    }
}
