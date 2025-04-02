using System.Reactive.Linq;

using gratch.Models;
using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<PeopleViewModel>]
public partial class PeoplePage : UserControl
{
    public PeoplePage()
    {
        this.InitializeComponent();
        this.ViewModel = Ioc.Container.GetService<PeopleViewModel>();
        
        this.OneWayBind(this.ViewModel, x => x.People, x => x.peopleListBox.DataSource);
        this.peopleListBox.DisplayMember = "Name";
        this.BindCommand(this.ViewModel, x => x.CreatePersonCommand, x => x.personAddButton);
        this.BindCommand(this.ViewModel, x => x.RemovePersonCommand, x => x.personRemoveButton);
        this.BindCommand(this.ViewModel, x => x.MoveUpCommand, x => x.personUpButton);
        this.BindCommand(this.ViewModel, x => x.MoveDownCommand, x => x.personDownButton);
        this.BindInteraction(this.ViewModel, x => x.CreatePersonDialog, context =>
        {
            var number = this.ViewModel!.SelectedGroup?.People.Count;
            MessageBox.Show($"Mock person #{number} created!");
            context.SetOutput($"Person #{number}");
            return Task.CompletedTask;
        });

        this.OneWayBind(this.ViewModel, x => x.Groups, x => x.groupsComboBox.DataSource);

        this.groupsComboBox.DisplayMember = "Name";
        this.OneWayBind(this.ViewModel, x => x.SelectedGroup, x => x.groupsComboBox.SelectedItem);
        Observable.FromEventPattern(ev => this.groupsComboBox.SelectedValueChanged += ev, ev => this.groupsComboBox.SelectedValueChanged -= ev)
            .Select(_ => this.groupsComboBox.SelectedItem)
            .BindTo(this.ViewModel, vm => vm.SelectedGroup);

        this.BindCommand(this.ViewModel, x => x.CreateGroupCommand, x => x.addGroupButton);
        this.BindCommand(this.ViewModel, x => x.RemoveGroupCommand, x => x.removeGroupButton,
            this.ViewModel.WhenAnyValue(x => x.SelectedGroup));
        this.BindInteraction(this.ViewModel, x => x.CreateGroupDialog, context =>
        {
            var number = this.ViewModel!.Groups.Count;

            MessageBox.Show($"Mock group #{number} created!");
            context.SetOutput($"Group #{number}");
            return Task.CompletedTask;
        });
    }
}
