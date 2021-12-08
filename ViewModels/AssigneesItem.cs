using ReactiveUI.Fody.Helpers;

namespace gratch_desktop.ViewModels
{
    public class AssigneesItem
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string Group { get; set; }
    }
}
