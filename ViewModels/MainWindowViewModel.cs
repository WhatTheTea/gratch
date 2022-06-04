
using DynamicData;

using ReactiveUI;

using Splat;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

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
            //Update logic
            static bool isMonthDiffer(gratch_core.Group grp) =>
                                      grp.Any(p =>
                                      p.DutyDates.Any(d =>
                                      d.Month != DateTime.Now.Month));

            var groupsToUpdate = groupService.Connect()
                                             .Filter(g => isMonthDiffer(g))
                                             .ToCollection()
                                             .Subscribe(list =>
                                             {
                                                 foreach (var group in list)
                                                 {
                                                     group.Graph.MonthlyUpdate();
                                                 }
                                             });

            //Router things
            Router = new RoutingState();

            Locator.CurrentMutable.RegisterLazySingleton(() =>
            new ViewLocator(), typeof(IViewLocator));
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            GoHome = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new HomeViewModel(this)));

            GoGroup = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new GroupViewModel(this)));

            GoGraph = ReactiveCommand.CreateFromObservable(() =>
            Router.Navigate.Execute(new GraphViewModel(this)));


        }
    }
}
