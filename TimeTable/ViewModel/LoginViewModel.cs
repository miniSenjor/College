using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    public class LoginViewModel
    {
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(Login);
                return _loginCommand;
            }
        }

        private void Login(object obj)
        {
            Navigation.Navigate(new TimeTableView());
        }
    }
}
