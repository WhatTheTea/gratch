using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace gratch_desktop.ViewModels
{
    internal class HomeViewModel : BaseViewModel
    {
        [Reactive]
        public string test { get; set; }
    }
}
