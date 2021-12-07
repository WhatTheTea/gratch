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

namespace gratch_desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для GroupCard.xaml
    /// </summary>
    public partial class GroupCard : UserControl
    {
        public static DependencyProperty GroupNameProperty;
        public static DependencyProperty HolidaysProperty;
        public string GroupName
        {
            get => GetValue(GroupNameProperty) as string;
            set => SetValue(GroupNameProperty, value);
        }
        public string Holidays
        {
            get => GetValue(HolidaysProperty) as string;
            set => SetValue(HolidaysProperty, value);
        }

        static GroupCard()
        {
            GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(TodayCard));
            HolidaysProperty = DependencyProperty.Register("Holidays", typeof(string), typeof(TodayCard));
        }
        public GroupCard()
        {
            InitializeComponent();

            LayoutRoot.DataContext = this;
        }
    }
}
