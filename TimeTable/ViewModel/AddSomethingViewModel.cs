using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace TimeTable.ViewModel
{
    internal class AddSomethingViewModel
    {
        //Сabinet
        public AddSomethingViewModel() { }
        public AddSomethingViewModel(Сabinet cabinet)
        {
            
        }
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(Save);
                return _saveCommand;
            }
        }

        private void Save(object obj)
        {

        }
    }
}
