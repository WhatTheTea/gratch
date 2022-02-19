using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratch_desktop.ViewModels
{
    public class TextDialogViewModel
    {
        [Reactive]
        public string Text { get; set; }
        [Reactive]
        public string Result { get; set; }

        public TextDialogViewModel() { }

        public TextDialogViewModel(string text)
        {
            Text = text;
            Result = null;
        }
    }
}
