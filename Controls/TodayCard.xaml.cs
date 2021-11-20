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
    /// Логика взаимодействия для InfoCard.xaml
    /// </summary>
    public partial class TodayCard : UserControl
    {
        public static DependencyProperty GroupNameProperty { get; set; }
        public static DependencyProperty AssignedPersonProperty { get; set; }
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

        static TodayCard()
        {
            GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(TodayCard));
            AssignedPersonProperty = DependencyProperty.Register("AssignedPerson", typeof(string), typeof(TodayCard));
        }
        public TodayCard()
        {
            InitializeComponent();
        }
    }
}
