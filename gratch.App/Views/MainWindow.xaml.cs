using Microsoft.UI.Xaml;

using WhatTheTea.Gratch.Models;
using WhatTheTea.Gratch.Services.Storage;
using WhatTheTea.Gratch.ViewModels;

namespace WhatTheTea.Gratch.App.Views;

public sealed partial class MainWindow : Window
{
    private readonly IDataStorage<Arrangement[]> arrangementStorage = new JsonDataStorage<Arrangement[]>();
    public MainViewModel MainViewModel { get; }

    public MainWindow()
    {
        this.MainViewModel = new(this.arrangementStorage);

        this.InitializeComponent();
    }
}
