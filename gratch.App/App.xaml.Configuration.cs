using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.App.Views.Pages;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Services.Storage;
using WhatTheTea.Gratch.ViewModels;

namespace WhatTheTea.Gratch.App;
public partial class App
{
    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public static new App Current => (App)Application.Current;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider Services { get; }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<IDataStorage<Arrangement>, JsonDataStorage<Arrangement>>();
        services.ConfigureViewModels();
        services.ConfigureViewsForViewModels();

        return services.BuildServiceProvider();
    }
}

static file class ConfigurationExtensions
{
    public static IServiceCollection ConfigureViewModels(this IServiceCollection services) =>
        services.AddSingleton<MainViewModel>()
                .AddTransient<Func<Arrangement, ArrangementViewModel>>(s =>
                    (a) => new ArrangementViewModel(a))
                .AddTransient<HomeViewModel>()
                .AddTransient<AboutViewModel>()
        ;

    public static IServiceCollection ConfigureViewsForViewModels(this IServiceCollection services) =>
        services.AddTransient<IViewFor<HomeViewModel>, HomePage>()
                .AddTransient<IViewFor<AboutViewModel>, AboutPage>()
                .AddTransient<IViewFor<ArrangementViewModel>, ArrangementPage>()
        ;
}
