using System.Windows;
using System.Windows.Controls;

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
