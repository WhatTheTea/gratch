using gratch.ViewModels;

using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<ScheduleViewModel>]
public partial class SchedulePage : UserControl
{
    public SchedulePage()
    {
        this.InitializeComponent();
        this.ViewModel = new();
    }
}
