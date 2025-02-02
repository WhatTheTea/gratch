using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<ScheduleViewModel>]
public partial class SchedulePage : UserControl
{
    public SchedulePage()
    {
        this.InitializeComponent();
        this.ViewModel = Ioc.Container.GetRequiredService<ScheduleViewModel>();
    }
}
