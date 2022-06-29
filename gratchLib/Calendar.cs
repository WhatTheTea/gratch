using System.Reactive.Subjects;

namespace gratchLib
{
    public abstract class Calendar : IDisposable, ICalendar
    {
        protected bool disposedValue;
        protected DateTime startDate;

        protected Subject<Calendar> whenHolidaysChanged = new();
        protected Subject<Calendar> whenWeekendsChanged = new();

        protected List<Holiday> holidays = new();
        protected List<DayOfWeek> weekend = new();

        public virtual IList<Holiday> Holidays => holidays.AsReadOnly();
        public virtual IList<DayOfWeek> Weekend => weekend.AsReadOnly();
        public virtual DateTime StartDate => startDate;

        public IObservable<Calendar> WhenHolidaysChanged => whenHolidaysChanged;
        public IObservable<Calendar> WhenWeekendsChanged => whenWeekendsChanged;


        public virtual void AddHoliday(Holiday holiday)
        {
            holidays.Add(holiday);
            whenHolidaysChanged.OnNext(this);
        }
        public virtual void RemoveHoliday(Holiday holiday)
        {
            holidays.Remove(holiday);
            whenHolidaysChanged.OnNext(this);
        }
        public virtual void RemoveHolidayAt(int index)
        {
            holidays.RemoveAt(index);
            whenHolidaysChanged.OnNext(this);
        }

        public virtual void AddDayOff(DayOfWeek day)
        {
            weekend.Add(day);
            whenWeekendsChanged.OnNext(this);
        }
        public virtual void RemoveDayOff(DayOfWeek day)
        {
            weekend.Remove(day);
            whenWeekendsChanged.OnNext(this);
        }

        /// <summary>Determines if date belongs to <see cref="Holidays"/> or <see cref="Weekend"/></summary>
        public virtual bool IsHoliday(DateTime date)
        {
            return Weekend.Contains(date.DayOfWeek) ||
                   Holidays.Any(day => day.IsEqual(date));
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    whenHolidaysChanged.Dispose();
                    whenWeekendsChanged.Dispose();
                }


                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}