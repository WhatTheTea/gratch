using gratch.Arrangement;
using gratch.Models;
using gratch.Utilities;

namespace gratch.Services;
public class ArrangementService : IArrangementService
{
    private readonly Dictionary<Group, IArranger<Person>> arrangers = []; 

    public Person? GetArrangedPersonOn(Group group, DateTime dateTime)
    {
        var arranger = this.GetArrangerFor(group);
        return arranger.ArrangeFor(dateTime);
    }

    public Models.Arrangement GetArrangementFor(Group group, DateTime start, DateTime end)
    {
        var arranger = this.GetArrangerFor(group);
        return new(arranger.ArrangeFor(start, end));
    }

    public IArranger<Person> GetArrangerFor(Group group) =>
        new Arranger<Person>(group.People, group.BaseDateTime)
                .ConfigureRules(group.ArrangementConfiguration);
}
