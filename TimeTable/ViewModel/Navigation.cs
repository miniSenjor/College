using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TimeTable.ViewModel
{
    public class Navigation
    {
        private static Frame _mainFrame;

        public static void Initialize(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }

        public static void Navigate(Page page)
        {
            _mainFrame.Content = page;
        }

        public static void GoBack()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }
    }
}
