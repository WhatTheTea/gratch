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

            Interactions.TextDialogClicked += Interactions_TextDialogClicked;
        }

        private void Interactions_TextDialogClicked(object sender, TextDialogViewModel e)
        {
            if (sender != null)
            {
                //int index = this.GroupsList.Items.IndexOf(sender as string);
                //this.GroupsList.Items[index] = e.Result;
                this.GroupsList.Items.Refresh();
            }
        }
    }
}
