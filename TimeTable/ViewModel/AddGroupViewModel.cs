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
    internal class AddGroupViewModel
    {
        public AddGroupViewModel()
        {
            _context = App.GetContext();
            Group = new Group();
            Groups = new ObservableCollection<Group>(_context.Group);
        }
        private TimeTableEntities _context;
        private Group _group;
        public Group Group
        {
            get => _group;
            set => SetField(ref _group, value);
        }
        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => SetField(ref _groups, value);
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

        private RelayCommand _newGroupCommand;
        public RelayCommand NewGroupCommand
        {
            get
            {
                if (_newGroupCommand == null)
                    _newGroupCommand = new RelayCommand(NewGroup);
                return _newGroupCommand;
            }
        }

        private void NewGroup(object obj)
        {
            Navigation.Navigate(new AddGroupView());
        }

        private RelayCommand _deleteGroupCommand;
        public RelayCommand DeleteGroupCommand
        {
            get
            {
                if (_deleteGroupCommand == null)
                    _deleteGroupCommand = new RelayCommand(DeleteGroup);
                return _deleteGroupCommand;
            }
        }

        private void DeleteGroup(object obj)
        {
            try
            {
                _context.Group.Remove(Group);
                _context.SaveChanges();
                MessageBox.Show("Группа успешно удален!");
                Navigation.Navigate(new AddGroupView());
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
                _context.Group.AddOrUpdate(Group);
                _context.SaveChanges();
                MessageBox.Show("Группа успешно добавлен!");
                Groups = new ObservableCollection<Group>(_context.Group);
                //Navigation.Navigate(new AddGroupView());
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
