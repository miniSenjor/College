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
using TimeTable.View;
using TimeTable.ViewModel;

namespace TimeTable
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ///<summary>Инициализируем нашу страницу для отражения таблицы с группами</summary>
            ///<inheritdoc/>
            Navigation.Initialize(MainFrame);
            ///<summary>Возращение к странице с авторизацией</summary>
            Navigation.Navigate(new AddSubjectView());
        }
    }
}
