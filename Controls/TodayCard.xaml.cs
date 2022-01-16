using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gratch_desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для TodayCard.xaml
    /// </summary>
    public partial class TodayCard : UserControl
    {
        public static readonly DependencyProperty GroupProperty
        = DependencyProperty.Register("Group", typeof(string), typeof(TodayCard));
        public static readonly DependencyProperty AssignedPersonProperty
        = DependencyProperty.Register("AssignedPerson", typeof(string), typeof(TodayCard));

        public string Group
        {
            get => GetValue(GroupProperty) as string;
            set => SetValue(GroupProperty, value);
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

        public static readonly DependencyProperty CommandProperty
        = DependencyProperty.Register("Command", typeof(ICommand), typeof(TodayCard));
        public ICommand Command
        {
            get => GetValue(CommandProperty) as ICommand;
            set => SetValue(CommandProperty, value);
        }

    }
}
