using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

using gratch.Helpers;
using gratch.Models;
using gratch.Services;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class PeopleViewModel(IGroupRepository groupRepository) : ReactiveObject
{
    private Group? selectedGroup;

    [Reactive]
    private Person? selectedPerson;

    public BindingList<Group> Groups { get; } = [];

    public BindingList<Person> People { get; } = [];

    public Interaction<Unit, string?> CreatePersonDialog { get; } = new();

    public Interaction<Unit, string?> CreateGroupDialog { get; } = new();

    public Group? SelectedGroup
    {
        get => this.selectedGroup;
        set
        {
            if (this.RaiseAndSetIfChanged(ref this.selectedGroup, value) is not null)
            {
                this.People.Clear();
                foreach (var item in value?.People ?? [])
                {
                    this.People.Add(item);
                }
                this.SelectedPerson = this.People.FirstOrDefault();
            }
        }
    }

    private IObservable<bool> whenPersonIsNotNull =>
        this.WhenAnyValue(x => x.SelectedPerson)
            .Select(x => x is not null);

    private IObservable<bool> whenGroupIsNotNull =>
        this.WhenAnyValue(x => x.SelectedGroup)
            .Select(x => x is not null);

    public async Task Initialize()
    {
        var groups = await groupRepository.GetGroupsAsync();

        foreach (var item in groups)
        {
            this.Groups.Add(item);
        }

        this.SelectedGroup = this.Groups.FirstOrDefault();
    }

    [ReactiveCommand(CanExecute = nameof(whenPersonIsNotNull))]
    private void MoveUp(Person person)
    {
        int index = this.People.IndexOf(person);

        if (index <= 0)
        {
            return;
        }

        (this.People[index], this.People[index - 1]) = (this.People[index - 1], this.People[index]);
        this.SelectedPerson = this.People[index - 1];
    }

    [ReactiveCommand(CanExecute = nameof(whenPersonIsNotNull))]
    private void MoveDown(Person person)
    {
        int index = this.People.IndexOf(person);

        if (index >= this.People.Count - 1)
        {
            return;
        }

        (this.People[index], this.People[index + 1]) = (this.People[index + 1], this.People[index]);
        this.SelectedPerson = this.People[index + 1];
    }

    [ReactiveCommand(CanExecute = nameof(whenPersonIsNotNull))]
    private void RemovePerson(Person person)
    {
        bool isRemoved = false;
        if (this.SelectedGroup is not null)
        {
            isRemoved = this.SelectedGroup?.People.Remove(person) ?? false;
            this.People.Remove(person);
        }

        if (isRemoved)
        {
            groupRepository.UpdateGroupAsync(this.SelectedGroup!);
        }
    }

    [ReactiveCommand(CanExecute = nameof(whenGroupIsNotNull))]
    private async Task CreatePerson()
    {
        var name = await this.CreatePersonDialog.Handle(Unit.Default);

        if (!Person.Validate.Name(name))
        {
            return;
        }

        var person = new Person(Guid.NewGuid().ToString(), name);

        if (this.SelectedGroup is not null)
        {
            this.SelectedGroup?.People.Add(person);
            this.People.Add(person);
        }
    }

    [ReactiveCommand]
    private async Task CreateGroup()
    {
        var name = await this.CreateGroupDialog.Handle(Unit.Default);

        if (!Group.Validate.Name(name))
        {
            return;
        }

        var group = await groupRepository.CreateGroupAsync(name);

        this.Groups.Add(group);
        this.SelectedGroup = group;
    }

    [ReactiveCommand(CanExecute = nameof(whenGroupIsNotNull))]
    private async Task RemoveGroup(Group group)
    {
        var index = this.Groups.IndexOf(group);
        await groupRepository.DeleteGroupAsync(group.Id);

        this.Groups.Remove(group);

        this.SelectedGroup = this.Groups.ElementAtNearest(index);
    }
}
