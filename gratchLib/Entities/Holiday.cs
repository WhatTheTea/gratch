namespace gratchLib.Entities
{
    public class Holiday
    {
        private string name = string.Empty;
        private DateTime date = DateTime.MinValue;

        public int Id { get; set; }
        public Calendar Calendar { get; set; }
        public virtual DateTime Date { get => date; protected set => date = value; }
        public virtual string Name { get => name; protected set => name = value; }
        public Holiday(DateTime date, string name)
        {
            Date = date;
            Name = name;
        }
        public Holiday() { }

        public virtual bool IsToday() => Date.Date == DateTime.Today;
        public virtual bool IsEqual(DateTime date) => Date.Date == date.Date;
    }
}
