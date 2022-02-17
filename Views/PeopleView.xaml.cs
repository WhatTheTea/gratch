using ReactiveUI;

using System.Reactive.Disposables;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для PeopleView.xaml
    /// </summary>
    public partial class PeopleView : ReactiveUserControl<ViewModels.PeopleViewModel>
    {
        public PeopleView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                // Add Person
                this.BindCommand(ViewModel,
                                 vm => vm.AddPerson,
                                 vw => vw.AddButton)
                    .DisposeWith(disposables);
                // List
                this.OneWayBind(ViewModel,
                                vm => vm.People,
                                vw => vw.PeopleListView.ItemsSource)
                    .DisposeWith(disposables);
            });
        }
    }
}
