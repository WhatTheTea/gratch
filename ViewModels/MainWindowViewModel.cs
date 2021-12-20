using gratch_desktop.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Splat;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IScreen
    {
        public RoutingState Router { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoHome { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoGroup { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoGraph { get; }

        public MainWindowViewModel()
        {
            Router = new RoutingState();

            Locator.CurrentMutable.RegisterLazySingleton(() => 
            new ViewLocator(), typeof(IViewLocator));

            GoHome = ReactiveCommand.CreateFromObservable(() => 
            Router.Navigate.Execute(new HomeViewModel()));

            GoGroup = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new GroupViewModel()));

            GoGraph = ReactiveCommand.CreateFromObservable(() => 
            Router.Navigate.Execute(new GraphViewModel()));
        }
    }
}
