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
    /// Логика взаимодействия для AddSubjectNameView.xaml
    /// </summary>
    public partial class AddSubjectNameView : Page
    {
        public AddSubjectNameView()
        {
            InitializeComponent();
            DataContext = new AddSubjectNameViewModel();
        }
    }
}
