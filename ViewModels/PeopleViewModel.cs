using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;

namespace gratch_desktop.ViewModels
{
    public class PeopleViewModel : BaseViewModel, IRoutableViewModel
    {
        public string UrlPathSegment => "/groups/people";
        public IScreen HostScreen { get; }
    }
}
