using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ReactiveUI;

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
            GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(GroupCard));
            HolidaysProperty = DependencyProperty.Register("Holidays", typeof(string), typeof(GroupCard));
        }
        public GroupCard()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
    }
}
