using gratch_desktop.ViewModels;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Splat;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ControlModels
{
    public class GroupCardModel : ReactiveObject
    {
        public IScreen HostScreen { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoPeople { get; }
        [Reactive]
        public string GroupName { get; set; }
        [Reactive]
        public string Holidays { get; set; }

        public GroupCardModel(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            GoPeople = ReactiveCommand.CreateFromObservable(() =>
                HostScreen.Router.Navigate.Execute(new PeopleViewModel()));


        }

    }
}
