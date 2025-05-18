using gratch.app.Services;

using Microsoft.Extensions.DependencyInjection;

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

        var mainWindow = new MainWindow();
        Application.Run(mainWindow);
    }

    private static async Task InitializeGroups()
    {
        var groupManager = Ioc.Container.GetRequiredService<IGroupManager>();
        await groupManager.Load();
    }
}