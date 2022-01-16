
using ReactiveUI;

using Splat;

using System.Reactive;

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
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            GoHome = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new HomeViewModel()));

            GoGroup = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new GroupViewModel()));

            GoGraph = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new GraphViewModel()));

            
        }
    }
}
