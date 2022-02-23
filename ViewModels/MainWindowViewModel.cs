
using ReactiveUI;

using Splat;

using System;
using System.Linq;
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
            var groups = groupService.Groups;
            //Update logic
            static bool isMonthDiffer(gratch_core.Group grp) =>
                                      grp.Any(p =>
                                      p.DutyDates.Any(d =>
                                      d.Month != DateTime.Now.Month));
            foreach (var group in groups)
            {
                if (isMonthDiffer(group))
                {
                    group.Graph.MonthlyUpdate();

                }
            }
            //Router things
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
