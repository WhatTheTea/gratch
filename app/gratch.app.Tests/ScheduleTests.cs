using gratch.Services;
using gratch.ViewModels;

using NSubstitute;

namespace gratch.app.Tests;

public class ScheduleTests
{
    [Fact]
    public void ScheduleCreatedIdealCase()
    {
        var groupManager = CommonFactory.CreateGroupManagerSubstitute(CommonFactory.CreateTestGroup());
        var arrangementManager = Substitute.For<IArrangementService>();

        var schedule = new GroupScheduleViewModel(groupManager, arrangementManager);

        arrangementManager.ReceivedWithAnyArgs().GetArrangementFor(default!, default, default);
    }
}
