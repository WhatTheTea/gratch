using gratch.ViewModels;

using ReactiveUI.SourceGenerators;

namespace gratch.classic;

[IViewFor<AppViewModel>]
public partial class MainWindow : Form
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.ViewModel = new();
    }
}
