using gratch.classic.Contracts;

using Microsoft.Extensions.DependencyInjection;

namespace gratch.classic;

internal static class Ioc
{
    public static IServiceProvider Container { get; set; } = new ServiceCollection().BuildServiceProvider();
}

internal partial class Program
{
    public static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IMainView, MainWindow>();

        Ioc.Container = services.BuildServiceProvider();
    }
}
