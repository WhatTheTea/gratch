

namespace gratchLib
{
    public abstract class Group : IDisposable, IAssignable<Schedule>
    {
        private bool disposedValue;
        protected List<Person> people = new();

        private List<IDisposable> subscriptions = new();

        public virtual string Name { get; set; } = string.Empty;
        public virtual IList<Person> People => people.AsReadOnly();
        public virtual IList<Person> ActivePeople => activePeople.ToList()
                                                                 .AsReadOnly();
        public virtual Calendar Calendar { get; } = new Calendar();

        protected IEnumerable<Person> activePeople => people.Where(x => x.Position > 0)
                                                            .OrderBy(x => x.Position);

        public virtual void AddPerson(string name)
        {
            if (!Contains(name))
            {
                var person = new Person(this, name);
                var sub = person.WhenPositionChanged.Subscribe(x => ShiftPositionsAfter(x));

                people.Add(person);
                subscriptions.Add(sub);
            }
        }
        public virtual void RemovePerson(Person person)
        {
            if (People.Contains(person))
            {
                people.Remove(person);
                person.Dispose();
                NormalizePositions();
                // TODO: Notify
            }
        }

        public virtual void AssignTo(Schedule schedule)
        {
            foreach (var person in People)
            {
                person.AssignTo(schedule);
            }
        }
        public virtual bool Contains(string name) => People.Any(p => p.Name == name);
        protected virtual void NormalizePositions()
        {
            // Select all people with positions in ascending order
            var activepeople = activePeople;
            // remove gaps in positions
            for (int i = 0; i < activepeople.Count(); i++)
            {
                activepeople.ElementAt(i).Position = i + 1;
            }

        }
        protected virtual void ShiftPositionsAfter(Person person)
        {
            // TODO: Logic to change position
            if(person.Position > 0)
            {
                var peopleAfterPerson = activePeople.SkipWhile(x => x.Position != person.Position);

                foreach (var p in peopleAfterPerson)
                {
                    if (p == person) continue;
                    p.Position += 1;
                }
            }
        }
        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    subscriptions.ForEach(s => s.Dispose());
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
