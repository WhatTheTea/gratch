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
    /// Логика взаимодействия для PersonListItem.xaml
    /// </summary>
    public partial class PersonListItem : UserControl
    {
        public static DependencyProperty PersonNameProperty;
        public string PersonName
        {
            get => GetValue(PersonNameProperty) as string;
            set => SetValue(PersonNameProperty, value);
        }
        static PersonListItem()
        {
            PersonNameProperty = DependencyProperty.Register("PersonName", typeof(string), typeof(PersonListItem));
        }

        public PersonListItem()
        {
            InitializeComponent();

            LayoutRoot.DataContext = this;
        }
    }
}
