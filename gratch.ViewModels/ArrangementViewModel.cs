using CommunityToolkit.Mvvm.ComponentModel;

using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.ViewModels;
public class ArrangementViewModel(Arrangement arrangement) : ObservableObject
{
    public string Title { get; set; } = string.Empty;
    public Arrangement Arrangement { get; } = arrangement;
}
