using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

using WhatTheTea.Gratch.ViewModels;

namespace WhatTheTea.Gratch.App.Views;

public sealed partial class MainWindow : Window
{
    public MainViewModel ViewModel { get; }

    public MainWindow()
    {
        this.ViewModel = App.Current.Services.GetService<MainViewModel>();

        this.InitializeComponent();
    }
}
