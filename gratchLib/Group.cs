

namespace gratchLib
{
    public abstract class Group : IDisposable
    {
        private bool disposedValue;
        protected List<Person> people = new();

        protected List<IDisposable> subscriptions = new();

        public virtual string Name { get; set; } = string.Empty;
        public virtual IList<Person> People => people.AsReadOnly();
        /// <summary>
        /// Readonly collection of <see cref="Person"/> with <see cref="Person.Position"/> bigger than 0 and ordered by ascending of <see cref="Person.Position"/>
        /// </summary>
        public virtual IList<Person> ActivePeople => activePeople.ToList()
                                                                 .AsReadOnly();
        public abstract Calendar Calendar { get; protected set; }

        protected IEnumerable<Person> activePeople => people.Where(x => x.IsActive)
                                                            .OrderBy(x => x.Position);

        public Group(string name)
        {
            this.Name = name;
        }

        public abstract void AddPerson(string name);
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
            if(person.IsActive)
            {
                List<Person> peopleToSkip = new() { person }; // Skip this <person>
                // Skip person with <person.Position>, that is not the same person
                activePeople.Where(p => p.Position == person.Position && p != person) 
                            .Select(p => p.Position += 1); // Also, shift its position right
                // NOTE: <person> and peopleToSkip may be in this collection too
                var peopleAfterPerson = activePeople.SkipWhile(x => x.Position != person.Position);

                foreach (var p in peopleAfterPerson)
                {
                    if (peopleToSkip.Contains(p)) continue; // skip peopleToSkip
                    p.Position += 1; // move everyone else
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
