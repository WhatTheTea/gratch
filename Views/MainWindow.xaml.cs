using gratch_desktop.ViewModels;

using MahApps.Metro.Controls;

using MaterialDesignThemes.Wpf;

using ReactiveUI;

using System.Reactive.Disposables;
using System.Windows;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IViewFor<MainWindowViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
        .Register(nameof(ViewModel), typeof(MainWindowViewModel), typeof(MainWindow));
        public MainWindowViewModel ViewModel
        {
            get => (MainWindowViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel)value;
        }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposables =>
           {
               // Buttons
               this.BindCommand(ViewModel, vw => vw.GoHome, vm => vm.HomeButton)
                   .DisposeWith(disposables);
               this.BindCommand(ViewModel, vw => vw.GoGroup, vm => vm.PeopleButton)
                   .DisposeWith(disposables);
               this.BindCommand(ViewModel, vw => vw.GoGraph, vm => vm.GraphButton)
                   .DisposeWith(disposables);
               // ContentViewHost
               this.OneWayBind(ViewModel, vm => vm.Router, vw => vw.ContentViewHost.Router)
                   .DisposeWith(disposables);

               // Interaction handlers
               Interactions.TextDialog
                           .RegisterHandler(async interaction =>
                           {
                               var getname = await DialogHost.Show(interaction.Input);
                               interaction.SetOutput(getname as string);
                               //interaction.Input.Result = null;
                           })
                           .DisposeWith(disposables);

           });
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
