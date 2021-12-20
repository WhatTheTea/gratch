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
            return viewModel switch
            {
                MainWindowViewModel => new MainWindow(),
                HomeViewModel => new HomeView(),
                GroupViewModel => new GroupView(),
                GraphViewModel => new GraphView(),
                PeopleViewModel => new PeopleView(),
                _ => throw new Exception($"Could not find the view for view model {typeof(T).Name}.")
            };
        }
    }
}
