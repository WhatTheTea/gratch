using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI.SourceGenerators;

namespace gratch.classic;

[IViewFor<AppViewModel>]
public partial class MainWindow : Form
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.ViewModel = Ioc.Container.GetRequiredService<AppViewModel>();
    }
}
