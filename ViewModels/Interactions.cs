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
        public static Interaction<TextDialogViewModel, string> TextDialog = new();
        public static EventHandler<TextDialogViewModel> TextDialogEventHandler;
        public static event EventHandler<TextDialogViewModel> TextDialogClicked;
        private static string sender = null;
        private static TextDialogViewModel vm = null;

        public static void InvokeEvent()
        {
            TextDialogClicked.Invoke(sender, vm);
        }

        public static IObservable<string> GetTextDialogInteraction(string text, string sender = null)
        {
            Interactions.sender = sender;
            var textDialogVM = new TextDialogViewModel(text);
            Interactions.vm = textDialogVM;
            var result = TextDialog.Handle(textDialogVM);
            return result;
        }
    }
}
