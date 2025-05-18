using System.Reactive.Linq;

using DynamicData;

using gratch.app.Services;
using gratch.Models;
using gratch.ViewModels;

using NSubstitute;

using Shouldly;

namespace gratch.app.Tests;

public class PeopleTests
{
    [Fact]
    public async Task GroupCreated()
    {
        var groupProvider = CommonFactory.CreateGroupManagerSubstitute();
        var viewModel = new PeopleViewModel(groupProvider);
        viewModel.CreateGroupDialog.RegisterHandler(handler =>
        {
            handler.SetOutput("test");
        });

        await viewModel.CreateGroupCommand.Execute();

        viewModel.Groups.ShouldNotBeEmpty();
        viewModel.SelectedGroup.ShouldNotBeNull();
    }

    [Fact]
    public async Task GroupRemoved()
    {
        var group = CommonFactory.CreateTestGroup();
        var groupProvider = CommonFactory.CreateGroupManagerSubstitute(group);
        var viewModel = new PeopleViewModel(groupProvider);

        await viewModel.RemoveGroupCommand.Execute(group);

        viewModel.Groups.ShouldBeEmpty();
    }

    [Fact]
    public async Task CantExecutePeopleCommands_PersonIsNull()
    {
        var group = CommonFactory.CreateTestGroup();
        var groupProvider = CommonFactory.CreateGroupManagerSubstitute(group);
        var viewModel = new PeopleViewModel(groupProvider);

        (await viewModel.CreatePersonCommand.CanExecute.Take(1)).ShouldBeTrue();
        (await viewModel.RemovePersonCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveDownCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveUpCommand.CanExecute.Take(1)).ShouldBeFalse();
    }

    [Fact]
    public async Task CantExecutePeopleCommands_GroupIsNull()
    {
        var group = CommonFactory.CreateTestGroup();
        var groupProvider = CommonFactory.CreateGroupManagerSubstitute();
        var viewModel = new PeopleViewModel(groupProvider);

        (await viewModel.CreatePersonCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.RemovePersonCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveDownCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveUpCommand.CanExecute.Take(1)).ShouldBeFalse();
    }

    [Fact]
    public async Task CanExecutePeopleCommandsOnNewPerson()
    {
        var group = CommonFactory.CreateTestGroup();
        var groupProvider = CommonFactory.CreateGroupManagerSubstitute(group);
        var viewModel = new PeopleViewModel(groupProvider);
        viewModel.CreateGroupDialog.RegisterHandler(handler =>
        {
            handler.SetOutput("test");
        });

        await viewModel.CreateGroupCommand.Execute();

        viewModel.People.Add(new("123", "test"));
        viewModel.SelectedPerson = viewModel.People[0];

        (await viewModel.RemovePersonCommand.CanExecute.Take(1)).ShouldBeTrue();
        (await viewModel.MoveDownCommand.CanExecute.Take(1)).ShouldBeTrue();
        (await viewModel.MoveUpCommand.CanExecute.Take(1)).ShouldBeTrue();
    }

    [Fact]
    public async Task PersonMovesUp()
    {
        var testGroup = CommonFactory.CreateTestGroup();
        testGroup.People.Add(new("1", "1"));
        testGroup.People.Add(new("2", "2"));
        testGroup.People.Add(new("3", "3"));

        var groupProvider = CommonFactory.CreateGroupManagerSubstitute(testGroup);
        var viewModel = new PeopleViewModel(groupProvider);

        await viewModel.MoveUpCommand.Execute(viewModel.People[1]);

        viewModel.People[0].Name.ShouldBe("2");
    }

    [Fact]
    public async Task PersonMovesDown()
    {
        var testGroup = CommonFactory.CreateTestGroup();
        testGroup.People.Add(new("1", "1"));
        testGroup.People.Add(new("2", "2"));
        testGroup.People.Add(new("3", "3"));

        var groupProvider = CommonFactory.CreateGroupManagerSubstitute(testGroup);
        var viewModel = new PeopleViewModel(groupProvider);

        await viewModel.MoveDownCommand.Execute(viewModel.People[1]);

        viewModel.People[2].Name.ShouldBe("2");
    }
}