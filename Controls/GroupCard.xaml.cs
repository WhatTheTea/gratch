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
    public partial class GroupCard : ReactiveUserControl<ControlModels.GroupCardModel>
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

            ViewModel = new ControlModels.GroupCardModel();

            this.WhenAnyValue(x => x.GroupName)
                .Subscribe(x => ViewModel.GroupName = x);
            this.WhenAnyValue(x => x.Holidays)
                .Subscribe(x => ViewModel.Holidays = x);

            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel,
                          vm => vm.GroupName,
                          vw => vw.GroupNameText.Text)
                    .DisposeWith(disposables);
                this.Bind(ViewModel,
                          vm => vm.Holidays,
                          vw => vw.HolidaysText.Text)
                    .DisposeWith(disposables);
            });
        }
    }
}
