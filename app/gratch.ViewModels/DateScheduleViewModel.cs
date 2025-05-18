using gratch.Models;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class DateScheduleViewModel : ReactiveObject
{
    [Reactive]
    private DateTime selectedDate;

    [Reactive]
    private Dictionary<Group, Person> arrangements;
}
