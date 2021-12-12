using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    internal class GroupItem
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public string Holidays { get; set; }
    }
}
