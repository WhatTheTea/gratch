using gratch.Arrangement;
using gratch.Arrangement.Rules;

namespace gratch.Models;

public sealed class ArrangementConfiguration
{
    public bool IsEveryday { get; set; } = true;

    public IEnumerable<DateTimeOffset> DatesBlacklist { get; set; } = [];

    public IEnumerable<DayOfWeek> DaysBlacklist { get; set; } = [];
}

public static class ArrangementConfigurationExtensions
{
    public static IArranger<T> ConfigureRules<T>(this IArranger<T> arranger, ArrangementConfiguration configuration) =>
        arranger.ConfigureRules(x =>
            {
                if (configuration.IsEveryday)
                {
                    x.AddEverydayRule();
                }

                x.AddSkipExactDatesRule(configuration.DatesBlacklist);
                x.AddSkipWeekDaysRule(configuration.DaysBlacklist);
            });
}
