using gratch.Models;
using gratch.Services;
using gratch.ViewModels;

using NSubstitute;

using Shouldly;

namespace gratch.app.Tests;

public class PeopleTests
{
    [Fact]
    public async Task ViewmodelReturnsGroups()
    {
        var groupProvider = Substitute.For<IGroupRepository>();
        var groupMock = new Group { Id = "0", BaseDateTimeOffset = DateTimeOffset.Now, Name = "test" };
        groupProvider.GetGroupsAsync().Returns(Task.FromResult<Group[]>([groupMock]));
        var viewModel = new PeopleViewModel(groupProvider);

        await viewModel.Initialize();

        viewModel.Groups.ShouldNotBeEmpty();
    }
}