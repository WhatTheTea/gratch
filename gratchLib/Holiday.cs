using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib
{
    public abstract class Holiday
    {
        public virtual DateTime Date { get; } = DateTime.MinValue;
        public virtual string Name { get; } = string.Empty;

        public Holiday(DateTime date, string name)
        {
            Date = date;
            Name = name;
        }

        public virtual bool IsToday() => Date.Date == DateTime.Today;
        public virtual bool IsEqual(DateTime date) => Date.Date == date.Date;
    }
}
