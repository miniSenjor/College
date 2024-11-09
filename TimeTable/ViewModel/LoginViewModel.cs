using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.View;
using TimeTable.Model;
using System.Windows;
using System.Net;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;

namespace TimeTable.ViewModel
{
    public class LoginViewModel //: INotifyPropertyChanged
    {
        /*public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        public LoginViewModel() 
        {
            _context = App.GetContext();
        }

        private TimeTableEntities _context;

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(Authorization);
                return _loginCommand;
            }
        }

        private string _login;
        private string _password;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private void Authorization(object obj)
        {
            if (_context.User.FirstOrDefault(u => u.login == _login && u.password == _password)!=null)
                Navigation.Navigate(new MainView(Login, Password));
        }
    }
}
