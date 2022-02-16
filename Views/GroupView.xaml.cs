using gratch_desktop.ViewModels;

using MaterialDesignThemes.Wpf;

using ReactiveUI;

using MahApps.Metro.Controls.Dialogs;

using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для GraphView.xaml
    /// </summary>
    public partial class GroupView : ReactiveUserControl<GroupViewModel>
    {
        public GroupView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                // getName handler
                this.ViewModel.GetName
                    .RegisterHandler(async interaction =>
                    {
                        var getname = await DialogHost.Show("Group name: ");
                        interaction.SetOutput(getname as string);
                    })
                    .DisposeWith(disposables);
                // Groups
                this.OneWayBind(ViewModel,
                                vm => vm.GroupItems,
                                vw => vw.GroupsList.ItemsSource)
                    .DisposeWith(disposables);
                // Add Group
                this.BindCommand(ViewModel,
                                 vm => vm.AddGroup,
                                 vw => vw.AddButton)
                    .DisposeWith(disposables);
            });
        }
    }
}
