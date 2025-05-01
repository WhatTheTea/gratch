using gratch.Arrangement;
using gratch.Models;

namespace gratch.Services;

/// <summary>
/// Provides a facade for arrangement system
/// </summary>
public interface IArrangementService
{
    IArranger<Person> GetArrangerFor(Group group);

    Person? GetArrangedPersonOn(Group group, DateTimeOffset dateTime);

    Models.Arrangement GetArrangementFor(Group group, DateTimeOffset start, DateTimeOffset end);
}
