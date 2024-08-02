using Microsoft.UI.Xaml.Controls;

using WhatTheTea.Gratch.Abstractions;
using WhatTheTea.Gratch.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WhatTheTea.Gratch.App.Views.Pages;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AboutPage : Page, IViewFor<AboutViewModel>
{
    public AboutViewModel ViewModel { get; }
    public AboutPage(AboutViewModel viewModel)
    {
        this.ViewModel = viewModel;
        this.InitializeComponent();
    }

}
