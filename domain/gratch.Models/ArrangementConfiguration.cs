namespace gratch.Models;

public sealed class ArrangementConfiguration
{
    public bool IsEveryday { get; set; } = true;

    public IEnumerable<DateTimeOffset> DatesBlacklist { get; set; } = [];

    public IEnumerable<DayOfWeek> DaysBlacklist { get; set; } = [];
}
