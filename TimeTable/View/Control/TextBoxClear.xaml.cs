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

namespace TimeTable.View.Control
{
    public partial class TextBoxClear : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "TextProperty", typeof(string), typeof(TextBoxClear), new FrameworkPropertyMetadata(string.Empty));

        public string Text
        {
            get => GetValue(TextProperty).ToString();
            set => SetValue(TextProperty, value);
        }

        public TextBoxClear()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text = string.Empty;
        }
    }
}
