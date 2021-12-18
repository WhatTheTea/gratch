﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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

using gratch_desktop.ViewModels;

using MahApps.Metro.Controls;

using ReactiveUI;

namespace gratch_desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IViewFor<MainWindowViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
        .Register(nameof(ViewModel), typeof(MainWindowViewModel), typeof(MainWindow));
        public MainWindowViewModel ViewModel
        {
            get => (MainWindowViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel)value;
        }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposables =>
           {
               this.BindCommand(ViewModel, vw => vw.GoHome, vm => vm.HomeButton)
                   .DisposeWith(disposables);
               this.BindCommand(ViewModel, vw => vw.GoGroup, vm => vm.PeopleButton)
                   .DisposeWith(disposables);
               this.BindCommand(ViewModel, vw => vw.GoGraph, vm => vm.GraphButton)
                   .DisposeWith(disposables);
               this.OneWayBind(ViewModel, vm => vm.Router, vw => vw.ContentViewHost.Router)
                   .DisposeWith(disposables);

           });
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HolidaysCheckDialogWindow().ShowDialog();
        }
    }
}
