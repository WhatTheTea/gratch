﻿using gratch.ViewModels;

using ReactiveUI.SourceGenerators;

namespace gratch.classic.Views;

[IViewFor<CalendarViewModel>]
public partial class HomePage : UserControl
{
    public HomePage()
    {
        this.InitializeComponent();
        this.ViewModel = new();
    }
}
