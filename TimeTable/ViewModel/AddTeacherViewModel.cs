using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    internal class AddTeacherViewModel
    {
        public AddTeacherViewModel()
        {
            _context = App.GetContext();
            Teacher = new Teacher();
            Teachers = new ObservableCollection<Teacher>( _context.Teacher);
        }
        private TimeTableEntities _context;
        private Teacher _teacher;
        public Teacher Teacher
        {
            get => _teacher;
            set => SetField(ref _teacher, value);
        }
        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set => SetField(ref _teachers, value);
        }
        private void SetField<T>(ref T field, T newValue)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(nameof(field));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            try
            {
            _context.Teacher.AddOrUpdate(Teacher);
                _context.SaveChanges();
                MessageBox.Show("Препод успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private RelayCommand _newTeacherCommand;
        public RelayCommand NewTeacherCommand
        {
            get
            {
                if (_newTeacherCommand == null)
                    _newTeacherCommand = new RelayCommand(NewTeacher);
                return _newTeacherCommand;
            }
        }

        private void NewTeacher(object obj)
        {
            Navigation.Navigate(new AddTeacherView());
        }

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

        private void Back(object obj)
        {
            Navigation.GoBack();
        }
    }
}
