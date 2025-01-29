using gratch.classic.Contracts;

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

        var mainWindow = (MainWindow)Ioc.Container.GetRequiredService<IMainView>();
        Application.Run(mainWindow);
    }
}