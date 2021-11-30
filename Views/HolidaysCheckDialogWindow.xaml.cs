using gratch_desktop.ViewModels;

using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
