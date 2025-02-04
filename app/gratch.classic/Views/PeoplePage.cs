using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<PeopleViewModel>]
public partial class PeoplePage : UserControl
{
    public PeoplePage()
    {
        this.InitializeComponent();
        this.ViewModel = Ioc.Container.GetRequiredService<PeopleViewModel>();
    }
}
