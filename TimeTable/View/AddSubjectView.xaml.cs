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
    /// Логика взаимодействия для AddSubjectView.xaml
    /// </summary>
    public partial class AddSubjectView : Page
    {
        public AddSubjectView()
        {
            InitializeComponent();
            DataContext = new AddSubjectViewModel();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectionItem = ((ListView)sender).SelectedItem as Subject;
            AddSubjectViewModel viewModel = DataContext as AddSubjectViewModel;
            viewModel.SelectedSubject = selectionItem;
            DataContext = new AddSubjectViewModel();
            DataContext = viewModel;
        }
    }
}
