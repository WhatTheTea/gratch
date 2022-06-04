using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using gratch_desktop.ViewModels;

using ReactiveUI;

namespace gratch_desktop.Controls
{
    /// <summary>
    /// Логика взаимодействия для GroupCard.xaml
    /// </summary>
    public partial class GroupCard : ReactiveUserControl<GroupItemViewModel>
    {
        #region old
        /*public static readonly DependencyProperty GroupNameProperty = 
            DependencyProperty.Register("GroupName", typeof(string), typeof(GroupCard));
        public static readonly DependencyProperty HolidaysProperty = 
            DependencyProperty.Register("Holidays", typeof(string), typeof(GroupCard));
        public static readonly DependencyProperty DeleteCommandProperty = 
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(GroupCard));
        public static readonly DependencyProperty RenameCommandProperty =
            DependencyProperty.Register("RenameCommand", typeof(ICommand), typeof(GroupCard));
        public ICommand RenameCommand
        {
            get => (ICommand)GetValue(RenameCommandProperty);
            set => SetValue(RenameCommandProperty, value);
        }
        public ICommand DeleteCommand
        {
            get => GetValue(DeleteCommandProperty) as ICommand;
            set => SetValue(DeleteCommandProperty, value);
        }


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
        */
        #endregion
        public GroupCard()
        {
            InitializeComponent();
            //LayoutRoot.DataContext = this;

            /*this.WhenActivated(disposables =>
            {
                // Text
                this.OneWayBind(ViewModel,
                                vm => vm.Holidays,
                                vw => vw.HolidaysTextBlock.Text)
                    .DisposeWith(disposables);
                this.OneWayBind(ViewModel,
                                vm => vm.Name,
                                vw => vw.NameLabel.Content)
                    .DisposeWith(disposables);
                // Commands
                this.BindCommand(ViewModel,
                                 vm => vm.DeleteCommand,
                                 vw => vw.DeleteMenuItem.Command)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel,
                                 vm => vm.RenameCommand,
                                 vw => vw.RenameMenuItem.Command)
                    .DisposeWith(disposables);
            });*/
        }
    }
}
