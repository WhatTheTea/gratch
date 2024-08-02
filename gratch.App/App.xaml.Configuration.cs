using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.UI.Xaml;

using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.App.Views;
using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Services.Storage;
using WhatTheTea.Gratch.ViewModels;

namespace WhatTheTea.Gratch.App;
public partial class App
{
    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;

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
        ;

    public static IServiceCollection ConfigureViewsForViewModels(this IServiceCollection services) => services;
}
