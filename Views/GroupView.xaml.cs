using gratch_desktop.ViewModels;

using ReactiveUI;

using System.Reactive.Disposables;

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
            });
        }
    }
}
