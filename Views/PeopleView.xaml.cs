using ReactiveUI;

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
        }
    }
}
