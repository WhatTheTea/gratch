using System.Reactive.Concurrency;
using System.Reactive.Linq;

using gratch.Models;
using gratch.Services;
using gratch.ViewModels;

using NSubstitute;

using Shouldly;

namespace gratch.app.Tests;

public class PeopleTests
{
    [Fact]
    public async Task GroupCreated()
    {
        var groupProvider = Substitute.For<IGroupRepository>();
        groupProvider.CreateGroupAsync(Arg.Is("test")).Returns(CreateTestGroup());
        var viewModel = new PeopleViewModel(groupProvider);
        await viewModel.Initialize();
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
        var groupProvider = Substitute.For<IGroupRepository>();
        var group = CreateTestGroup();
        groupProvider.GetGroupsAsync().Returns([group]);
        var viewModel = new PeopleViewModel(groupProvider);
        await viewModel.Initialize();

        await viewModel.RemoveGroupCommand.Execute(group);

        viewModel.Groups.ShouldBeEmpty();
    }

    [Fact]
    public async Task CantExecutePeopleCommands_PersonIsNull()
    {
        var groupProvider = Substitute.For<IGroupRepository>();
        groupProvider.GetGroupsAsync().Returns([CreateTestGroup()]);
        var viewModel = new PeopleViewModel(groupProvider);
        await viewModel.Initialize();

        (await viewModel.CreatePersonCommand.CanExecute.Take(1)).ShouldBeTrue();
        (await viewModel.RemovePersonCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveDownCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveUpCommand.CanExecute.Take(1)).ShouldBeFalse();
    }

    [Fact]
    public async Task CantExecutePeopleCommands_GroupIsNull()
    {
        var groupProvider = Substitute.For<IGroupRepository>();
        var viewModel = new PeopleViewModel(groupProvider);
        await viewModel.Initialize();

        (await viewModel.CreatePersonCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.RemovePersonCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveDownCommand.CanExecute.Take(1)).ShouldBeFalse();
        (await viewModel.MoveUpCommand.CanExecute.Take(1)).ShouldBeFalse();
    }

    [Fact]
    public async Task CanExecutePeopleCommandsOnNewPerson()
    {
        var groupProvider = Substitute.For<IGroupRepository>();
        groupProvider.CreateGroupAsync(Arg.Is("test")).Returns(CreateTestGroup());
        var viewModel = new PeopleViewModel(groupProvider);
        await viewModel.Initialize();
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

    private static Group CreateTestGroup(string name = "test") =>
        new() { Id = "test", Name = name, BaseDateTimeOffset = DateTimeOffset.Now };
}