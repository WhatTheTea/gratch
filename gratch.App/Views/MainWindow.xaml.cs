using Microsoft.UI.Xaml;

using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Services.Storage;
using WhatTheTea.Gratch.ViewModels;

namespace WhatTheTea.Gratch.App.Views;

public sealed partial class MainWindow : Window
{
    private IDataStorage<Arrangement[]> arrangementStorage = new JsonDataStorage<Arrangement[]>();
    public MainViewModel MainViewModel { get; } = new();

    public MainWindow()
    {
        this.InitializeComponent();
    }
}
