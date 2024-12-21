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
    internal class AddSubjectNameViewModel
    {
        public AddSubjectNameViewModel()
        {
            _context = App.GetContext();
            SubjectName = new SubjectName();
            SubjectNames = new ObservableCollection<SubjectName>(_context.SubjectName);
        }
        private TimeTableEntities _context;
        private SubjectName _subjectName;
        public SubjectName SubjectName
        {
            get => _subjectName;
            set => SetField(ref _subjectName, value);
        }
        private ObservableCollection<SubjectName> _subjectNames;
        public ObservableCollection<SubjectName> SubjectNames
        {
            get => _subjectNames;
            set => SetField(ref _subjectNames, value);
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

        private RelayCommand _newSubjectNameCommand;
        public RelayCommand NewSubjectNameCommand
        {
            get
            {
                if (_newSubjectNameCommand == null)
                    _newSubjectNameCommand = new RelayCommand(NewSubjectName);
                return _newSubjectNameCommand;
            }
        }

        private void NewSubjectName(object obj)
        {
            Navigation.Navigate(new AddSubjectNameView());
        }

        private RelayCommand _deleteSubjectNameCommand;
        public RelayCommand DeleteSubjectNameCommand
        {
            get
            {
                if (_deleteSubjectNameCommand == null)
                    _deleteSubjectNameCommand = new RelayCommand(DeleteSubjectName);
                return _deleteSubjectNameCommand;
            }
        }

        private void DeleteSubjectName(object obj)
        {
            try
            {
                _context.SubjectName.Remove(SubjectName);
                _context.SaveChanges();
                MessageBox.Show("Предмет успешно удален!");
                Navigation.Navigate(new AddSubjectNameView());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                _context.SubjectName.AddOrUpdate(SubjectName);
                _context.SaveChanges();
                MessageBox.Show("Кабинет успешно добавлен!");
                SubjectNames = new ObservableCollection<SubjectName>(_context.SubjectName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            Navigation.Navigate(new AddView());
        }
    }
}
