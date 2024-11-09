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
using TimeTable.ViewModel;

namespace TimeTable.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            ///<summary>Получаем логику из ViewModel для будущего взаимодействия с логикой</summary>
            DataContext = new MainViewModel();
            ///<summary>Заполняем данными из БД</summary>
            ///<remarks>Берём данные групп в листе, и заполняем</remarks>
            dgGroups.ItemsSource = App.GetContext().Group.ToList();
        }
    }
}
