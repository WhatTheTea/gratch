using gratch.ViewModels;

using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<PeopleViewModel>]
public partial class PeoplePage : UserControl
{
    public PeoplePage()
    {
        this.InitializeComponent();
        this.ViewModel = new();
    }
}
