
using ReactiveUI;

namespace gratch_desktop.ViewModels
{
    public class PeopleViewModel : BaseViewModel, IRoutableViewModel
    {
        public string UrlPathSegment => "/groups/people";
        public IScreen HostScreen { get; }
    }
}
