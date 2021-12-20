
using ReactiveUI.Fody.Helpers;

using System.Collections.ObjectModel;
using System.Windows;

namespace gratch_desktop.Views
{
    public class CheckedListItem
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public bool IsChecked { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для HolidaysCheckDialogWindow.xaml
    /// </summary>
    public partial class HolidaysCheckDialogWindow : MahApps.Metro.Controls.MetroWindow
    {
        public HolidaysCheckDialogWindow()
        {
            InitializeComponent();
        }

        [Reactive]
        public ObservableCollection<CheckedListItem> Holidays { get; set; }
            = new ObservableCollection<CheckedListItem>
            {
                new CheckedListItem{Name = "Monday", IsChecked = false},
                new CheckedListItem{Name = "Tuesday", IsChecked = false},
                new CheckedListItem{Name = "Wednesday", IsChecked = false},
                new CheckedListItem{Name = "Thursday", IsChecked = false},
                new CheckedListItem{Name = "Friday", IsChecked = false},
                new CheckedListItem{Name = "Saturday", IsChecked = false},
                new CheckedListItem{Name = "Sunday",  IsChecked = false},
            };
        [ReactiveDependency("Holidays")]
        public static DependencyProperty HolidaysProperty { get; set; }
    }
}
