using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.ViewModels;
/// <summary>
/// Provides data about arrangements and commands for manipulation
/// </summary>
public sealed partial class MainViewModel(IDataStorage<Arrangement[]> arrangementStorage) : ObservableObject
{
    private readonly IDataStorage<Arrangement[]> arrangementStorage = arrangementStorage;
    public ObservableCollection<Arrangement> Arrangements { get; } = [];
    /// <summary>
    /// Executes data retrieval on background thread and updates <see cref="Arrangements"/>
    /// </summary>
    [RelayCommand]
    private async Task LoadData()
    {
        var data = await Task.Run(this.arrangementStorage.LoadAsync);

        this.Arrangements.Clear();
        foreach (var arrangement in data)
        {
            this.Arrangements.Add(arrangement);
        }
    }

    /// <summary>
    /// Saves arrangements on background thread
    /// </summary>
    [RelayCommand]
    private async Task SaveData() =>
        await Task.Run(() => this.arrangementStorage.SaveAsync([.. this.Arrangements]));
}
