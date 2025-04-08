using System.Reactive.Threading.Tasks;

using gratch.app.Services;
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

        _ = InitializeGroups();

        var mainWindow = (Form)Ioc.Container.GetRequiredService<IViewFor<AppViewModel>>();
        Application.Run(mainWindow);
    }

    private static async Task InitializeGroups()
    {
        var groupManager = Ioc.Container.GetRequiredService<IGroupManager>();
        await groupManager.Load();
    }
}