using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gratch_desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для PersonListItem.xaml
    /// </summary>
    public partial class PersonListItem : UserControl
    {
        public static readonly DependencyProperty PersonNameProperty = 
            DependencyProperty.Register("PersonName", typeof(string), typeof(PersonListItem));
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(PersonListItem));
        // Using a DependencyProperty as the backing store for RenameCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RenameCommandProperty =
            DependencyProperty.Register("RenameCommand", typeof(ICommand), typeof(PersonListItem));

        public ICommand RenameCommand
        {
            get { return (ICommand)GetValue(RenameCommandProperty); }
            set { SetValue(RenameCommandProperty, value); }
        }

        public string PersonName
        {
            get => GetValue(PersonNameProperty) as string;
            set => SetValue(PersonNameProperty, value);
        }

        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        public PersonListItem()
        {
            InitializeComponent();

            LayoutRoot.DataContext = this;
        }
    }
}
