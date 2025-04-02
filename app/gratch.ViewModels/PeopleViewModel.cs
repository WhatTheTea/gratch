using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

using gratch.Models;
using gratch.Services;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class PeopleViewModel(IGroupRepository groupRepository) : ReactiveObject
{
    public BindingList<Group> Groups { get; } = [];

    public BindingList<Person> People { get; } = [];

    public Interaction<Unit, string> CreatePersonDialog { get; } = new();

    public Interaction<Unit, string> CreateGroupDialog { get; } = new();
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
            }
        }
    }

    private IObservable<bool> canExecutePeopleCommands = Observable.Return(false);

    private Group? selectedGroup;

    public async Task Initialize()
    {
        var groups = await groupRepository.GetGroupsAsync();

        foreach (var item in groups)
        {
            this.Groups.Add(item);
        }

        this.SelectedGroup = this.Groups.FirstOrDefault();
        this.canExecutePeopleCommands = this.WhenAnyValue(x => x.SelectedGroup).Select(x => x is not null).Publish().RefCount();
    }

    [ReactiveCommand(CanExecute = nameof(canExecutePeopleCommands))]
    private void MoveUp(Person person)
    {

    }

    [ReactiveCommand(CanExecute = nameof(canExecutePeopleCommands))]
    private void MoveDown(Person person)
    {

    }

    [ReactiveCommand(CanExecute = nameof(canExecutePeopleCommands))]
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

    [ReactiveCommand(CanExecute = nameof(canExecutePeopleCommands))]
    private async Task CreatePerson()
    {
        var name = await this.CreatePersonDialog.Handle(Unit.Default);

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

        var group = await groupRepository.CreateGroupAsync(name);

        this.Groups.Add(group);
        this.SelectedGroup = group;
    }

    [ReactiveCommand]
    private async Task RemoveGroup(Group group)
    {
        await groupRepository.DeleteGroupAsync(group.Id);

        this.Groups.Remove(group);
    }
}
