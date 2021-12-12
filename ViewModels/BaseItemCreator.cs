using DynamicData;

using gratch_core;

using gratch_desktop.Services;
using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    internal abstract class BaseItemCreator<T> where T : class
    {
        private readonly ReadOnlyObservableCollection<Group> _groups;

        protected ReadOnlyObservableCollection<Group> Groups => _groups;
        public abstract T Create();

        protected BaseItemCreator()
        {
            var service = new GroupService();
            var groups = service.Connect()
                        .Bind(out _groups)
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Subscribe();

            //this.WhenAnyValue(x => x.Groups)
            //    .Subscribe(x => Create());
        }
    }
}
