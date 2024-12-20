﻿using System;
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
using TimeTable.ViewModel;

namespace TimeTable.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView(string l = "Пусто", string p = "Пусто")
        {
            InitializeComponent();
            DataContext = new MainViewModel(l,p);
            tl.Text = l;
            tp.Text = p;
            //dgGroups.ItemsSource = App.GetContext().Group.ToList();
        }
    }
}
