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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI.Fody.Helpers;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        [ReactiveDependency("Assignees")]
        public static DependencyProperty AssigneesProperty { get; set; }
        public HomeView()
        {
            InitializeComponent();
            LayoutRoot.DataContext = new ViewModels.HomeViewModel();
        }
    }
}
