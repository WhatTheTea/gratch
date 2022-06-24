using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib
{
    public struct Holiday
    {
        public DateTime Date { get; private set; }
        public string Name { get; private set; }

        public Holiday(DateTime date, string name)
        {
            Date = date;
            Name = name;
        }

        public bool IsToday() => Date.Date == DateTime.Today;
        public bool IsEqual(DateTime date) => Date.Date == date.Date;
    }
}
