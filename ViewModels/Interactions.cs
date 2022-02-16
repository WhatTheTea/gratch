using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    internal static class Interactions
    {
        public static Interaction<string, string> TextDialog = new();
    }
}
