
using gratch_core;

using ReactiveUI;

using Splat;

namespace gratch_desktop.ViewModels
{
    public class PeopleViewModel : BaseViewModel, IRoutableViewModel
    {
        public string UrlPathSegment => "/groups/people";
        public IScreen HostScreen { get; }

        private IGroup _group;
        public IGroup Group { get => _group; set => _group = value; }

        public PeopleViewModel() { }
        public PeopleViewModel(IGroup group, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _group = group;
        }
    }
}
