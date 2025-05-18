using gratch.app.Services;
using gratch.Services;
using gratch.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using ReactiveUI;

using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace gratch.classic;

internal static class Ioc
{
    public static IServiceProvider Container { get; set; } = new ServiceCollection().BuildServiceProvider();
}

internal partial class Program
{
    /// <summary>
    /// Configuration root for gratch.classic
    /// </summary>
    public static void ConfigureServices()
    {
        var services = new ServiceCollection();
        services.UseMicrosoftDependencyResolver();
        Locator.CurrentMutable.InitializeSplat();
        Locator.CurrentMutable.InitializeReactiveUI();
        Locator.CurrentMutable.RegisterViewsForViewModels(System.Reflection.Assembly.GetEntryAssembly()!);

        services.AddSingleton<IGroupRepository, InMemoryGroupRepository>();
        services.AddSingleton<IArrangementService, ArrangementService>();
        services.AddSingleton<IGroupManager, GroupManager>();
        services.AddSingleton<PeopleViewModel>();
        services.AddSingleton<GroupScheduleViewModel>();

        Ioc.Container = services.BuildServiceProvider();
        Ioc.Container.UseMicrosoftDependencyResolver();
    }
}
