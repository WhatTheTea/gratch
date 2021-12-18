using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using gratch_desktop.ViewModels;
using gratch_desktop.Views;

namespace gratch_desktop
{
    public class ViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null)
        {
            if (viewModel is MainWindowViewModel)
                return new MainWindow { ViewModel = viewModel as MainWindowViewModel};
            if (viewModel is HomeViewModel)
                return new HomeView { ViewModel = viewModel as HomeViewModel};
            throw new Exception($"Could not find the view for view model {typeof(T).Name}.");
        }
    }
}
