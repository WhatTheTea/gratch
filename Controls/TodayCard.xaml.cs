using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для TodayCard.xaml
    /// </summary>
    public partial class TodayCard : UserControl
    {
        public static readonly DependencyProperty GroupNameProperty
        = DependencyProperty.Register("GroupName", typeof(string), typeof(TodayCard));
        public static readonly DependencyProperty AssignedPersonProperty
        = DependencyProperty.Register("AssignedPerson", typeof(string), typeof(TodayCard));

        public string GroupName
        {
            get => GetValue(GroupNameProperty) as string;
            set => SetValue(GroupNameProperty, value);
        }
        public string AssignedPerson
        {
            get => GetValue(AssignedPersonProperty) as string;
            set => SetValue(AssignedPersonProperty, value);
        }
        public TodayCard()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
    }
}
