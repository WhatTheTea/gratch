using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;

namespace gratch.classic;

internal static partial class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        ConfigureServices();

        var mainWindow = (Form)Ioc.Container.GetRequiredService<IViewFor<AppViewModel>>();
        Application.Run(mainWindow);
    }
}