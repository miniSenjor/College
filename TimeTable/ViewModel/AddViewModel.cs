using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    internal class AddViewModel
    {
        public AddViewModel()
        {
            _context = App.GetContext();
        }

        private TimeTableEntities _context;

        private RelayCommand _backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new RelayCommand(Back);
                return _backCommand;
            }
        }

        private RelayCommand _addCabinetCommand;
        public RelayCommand AddCabinetCommand
        {
            get
            {
                if (_addCabinetCommand == null)
                    _addCabinetCommand = new RelayCommand(AddCabinet);
                return _addCabinetCommand;
            }
        }

        private RelayCommand _addTeacherCommand;
        public RelayCommand AddTeacherCommand
        {
            get
            {
                if (_addTeacherCommand == null)
                    _addTeacherCommand = new RelayCommand(AddTeacher);
                return _addTeacherCommand;
            }
        }

        private RelayCommand _addGroupCommand;
        public RelayCommand AddGroupCommand
        {
            get
            {
                if (_addGroupCommand == null)
                    _addGroupCommand = new RelayCommand(AddGroup);
                return _addGroupCommand;
            }
        }

        private RelayCommand _addSubjectNameCommand;
        public RelayCommand AddSubjectNameCommand
        {
            get
            {
                if (_addSubjectNameCommand == null)
                    _addSubjectNameCommand = new RelayCommand(AddSubjectName);
                return _addSubjectNameCommand;
            }
        }

        private RelayCommand _addSubjectCommand;
        public RelayCommand AddSubjectCommand
        {
            get
            {
                if (_addSubjectCommand == null)
                    _addSubjectCommand = new RelayCommand(AddSubject);
                return _addSubjectCommand;
            }
        }

        private RelayCommand _editTimeTableCommand;
        public RelayCommand EditTimeTableCommand
        {
            get
            {
                if (_editTimeTableCommand == null)
                    _editTimeTableCommand = new RelayCommand(EditTimeTable);
                return _editTimeTableCommand;
            }
        }
        private void EditTimeTable(object obj)
        {
            Navigation.Navigate(new EditTimeTableView());
        }
        private void Back(object obj)
        {
            Navigation.Navigate(new LoginView());
        }

        private void AddCabinet(object obj)
        {
            Navigation.Navigate(new AddCabinetView());
        }
        private void AddTeacher(object obj)
        {
            Navigation.Navigate(new AddTeacherView());
        }
        private void AddGroup(object obj)
        {
            Navigation.Navigate(new AddGroupView());
        }
        private void AddSubjectName(object obj)
        {
            Navigation.Navigate(new AddSubjectNameView());
        }
        private void AddSubject(object obj)
        {
            Navigation.Navigate(new AddSubjectView());
        }
    }
}
