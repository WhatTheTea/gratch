using gratch.Models;

namespace gratch.Services;

public interface IArrangementService
{
    Models.Arrangement GetArrangementFor(DateTimeOffset start, DateTimeOffset end);

    Person GetArrangedPersonOn(DateTimeOffset dateTime);
}
