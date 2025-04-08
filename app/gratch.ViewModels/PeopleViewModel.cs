using System.ComponentModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

using DynamicData;

using gratch.app.Services;
using gratch.Helpers;
using gratch.Models;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.ViewModels;
public partial class PeopleViewModel : ReactiveObject
{
    private readonly IScheduler uiScheduler;

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
            .ObserveOn(this.uiScheduler)
            .Select(x => x is not null);

    private IObservable<bool> whenGroupIsNotNull =>
        this.WhenAnyValue(x => x.SelectedGroup)
            .ObserveOn(this.uiScheduler)
            .Select(x => x is not null);

    public PeopleViewModel(IGroupManager groupManager, IScheduler? uiScheduler = null)
    {
        this.uiScheduler = uiScheduler ?? RxApp.MainThreadScheduler;
        var changeSet = groupManager.Groups.Connect();

        changeSet
            .ObserveOn(this.uiScheduler)
            .Bind(this.Groups)
            .Subscribe();

        changeSet
            .ObserveOn(this.uiScheduler)
            .Take(1)
            .Subscribe(x => this.SelectedGroup = x.First().Current);
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
        if (this.SelectedGroup is not null)
        {
            this.People.Remove(person);
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

        var group = new Group(name);

        this.Groups.Add(group);
        this.SelectedGroup = group;
    }

    [ReactiveCommand(CanExecute = nameof(whenGroupIsNotNull))]
    private void RemoveGroup(Group group)
    {
        var index = this.Groups.IndexOf(group);

        this.Groups.Remove(group);

        this.SelectedGroup = this.Groups.ElementAtNearest(index);
    }
}
