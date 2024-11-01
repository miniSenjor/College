using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    public class MainViewModel
    {
        private RelayCommand _simpleCommand;
        public RelayCommand SimpleCommand
        {
            get
            {
                if (_simpleCommand == null)
                    _simpleCommand = new RelayCommand(SCommand);
                return _simpleCommand;
            }
        }

        private void SCommand(object obj)
        {
            MessageBox.Show("Privet");
        }
    }
}
