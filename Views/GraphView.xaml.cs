using System;
using System.Collections.Generic;
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

namespace gratch_desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.GraphViewModel();
        }

        // ?
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = GraphCalendar.SelectedDate ?? default;
            ((ViewModels.GraphViewModel)DataContext).CalendarDayCommand.Execute(date).Subscribe();
            GraphCalendar.SelectedDate = default;
        }
    }
}
