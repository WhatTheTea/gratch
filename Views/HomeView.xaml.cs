using gratch_desktop.ViewModels;

using ReactiveUI;

using System.Reactive.Disposables;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : ReactiveUserControl<HomeViewModel>
    {

        public HomeView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel,
                                vm => vm.Assignees,
                                vw => vw.CardsList.ItemsSource)
                    .DisposeWith(disposables);

            });
        }
    }
}
