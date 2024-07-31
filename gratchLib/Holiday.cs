namespace gratch.Core;

public class Holiday
{
    protected DateTime _date;
    protected string _name; // TODO: Fix name in DB

    public int Id { get; set; }
    public Calendar? Calendar { get; set; }
    public virtual DateTime Date => _date;
    public virtual string Name => _name;


    public Holiday() => (_name, _date) = (string.Empty, DateTime.MinValue);
    public Holiday(DateTime date, string name) => (_name, _date) = (name, date);

    public virtual bool IsToday() => Date.Date == DateTime.Today;
    public virtual bool IsEqual(DateTime date) => Date.Date == date.Date;
}
