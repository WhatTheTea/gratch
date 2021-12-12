using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gratch_core;

namespace gratch_desktop.ViewModels
{
    internal class GroupItemCreator : BaseItemCreator<GroupItem>
    {
        private Group selectedGroup;

        public Group SelectedGroup
        {
            get => selectedGroup;
            set => selectedGroup = value;
        }
        private List<DateTime> holidays
        {
            get
            {
                List<DateTime> result = null;
                var now = DateTime.Now;
                int holidaysCount = SelectedGroup.Graph.Weekend.Count;

                for (int i = 1, d = 1; i <= DateTime.Now.DaysInMonth() || d <= holidaysCount; i++)
                {
                    var date = new DateTime(now.Year, now.Month, i);
                    if (SelectedGroup.Graph.IsHoliday(date))
                    {
                        result.Add(date);
                    }
                }

                return result;

            }
        }

        public override GroupItem Create()
        {
            GroupItem result = new() { Name = string.Empty, Holidays = string.Empty };
            result.Name = SelectedGroup.Name;
            if (holidays != null)
            {
                string holidaysResult = "Holidays: ";
                foreach (var day in holidays)
                {
                    holidaysResult = (day != holidays.Last()) ? $@"{day:ddd}, " : $@"{day:ddd}";
                }
                result.Holidays = holidaysResult;
            } else
            {
                result.Holidays = "Holidays: None";
            }

            return result;
        }
    }
}
