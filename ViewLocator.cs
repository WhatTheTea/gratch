using gratch_desktop.Controls;

using gratch_desktop.ViewModels;
using gratch_desktop.Views;

using ReactiveUI;

using System;

namespace gratch_desktop
{
    public class ViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null)
        {
            return viewModel switch
            {
                // IScreen
                MainWindowViewModel => new MainWindow(),
                // Pages
                HomeViewModel => new HomeView(),
                GroupViewModel => new GroupView(),
                GraphViewModel => new GraphView(),
                PeopleViewModel => new PeopleView(),
                HolidaysDialogWindowViewModel => new HolidaysCheckDialogWindow(),
                // else
                _ => throw new Exception($"Could not find the view for view model {typeof(T).Name}.")
            };
        }
    }
}
