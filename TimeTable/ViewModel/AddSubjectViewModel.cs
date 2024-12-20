using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TimeTable.ViewModel
{
    internal class AddSubjectViewModel : INotifyPropertyChanged
    {
        private readonly TimeTableEntities _context;
        //без гет сет ошибка привязки данных через биндинг
        private ObservableCollection<SubjectName> _subjectNames;
        public ObservableCollection<SubjectName> SubjectNames
        {
            get => _subjectNames;
            set => SetField(ref _subjectNames, value);
        }
        private ObservableCollection<Teacher> _teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set => SetField(ref _teachers, value);
        }
        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => SetField(ref _groups, value);
        }
        private Subject _newSubject;
        public Subject NewSubject
        {
            get => _newSubject;
            set => SetField(ref _newSubject, value);
        }
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set => SetField(ref _selectedSubject, value);
        }
        private ObservableCollection<Subject> _listSubjects;
        public ObservableCollection<Subject> ListSubjects
        {
            get => _listSubjects;
            set => SetField(ref _listSubjects, value);
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

        private RelayCommand _createNewSubjectCommand;
        public RelayCommand CreateNewSubjectCommand
        {
            get
            {
                if (_createNewSubjectCommand == null)
                    _createNewSubjectCommand = new RelayCommand(CreateNewSubject);
                return _createNewSubjectCommand;
            }
        }
        private RelayCommand _saveSelectedSubjectCommand;
        public RelayCommand SaveSelectedSubjectCommand
        {
            get
            {
                if (_saveSelectedSubjectCommand == null)
                    _saveSelectedSubjectCommand = new RelayCommand(SaveSelectedSubject);
                return _saveSelectedSubjectCommand;
            }
        }



        public AddSubjectViewModel()
        {
            _context = App.GetContext();
            LoadData();
            NewSubject = new Subject();
            SelectedSubject = new Subject();
        }

        private void LoadData()
        {
            SubjectNames = new ObservableCollection<SubjectName>(_context.SubjectName.ToList());
            Teachers = new ObservableCollection<Teacher>(_context.Teacher.ToList());
            Groups = new ObservableCollection<Group>(_context.Group.ToList());
            ListSubjects = new ObservableCollection<Subject>(_context.Subject.ToList());
        }

        private void CreateNewSubject(object obj)
        {
            if (NewSubject.SubjectName == null || NewSubject.Group == null || NewSubject.Teacher == null)
            {
                MessageBox.Show("Не выбраны поля для создания Предмета");
                return;
            }
            try
            {
                _context.Subject.Add(NewSubject);
                _context.SaveChanges();
                ListSubjects.Add(NewSubject);
                MessageBox.Show("Предмет упешно создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления предмета");
            }
        }

        private void SaveSelectedSubject(object obj)
        {
            if (SelectedSubject.SubjectName == null)
            {
                MessageBox.Show("Не выбрано имя");
                return;
            }
            try
            {
                _context.Subject.AddOrUpdate(NewSubject);
                _context.SaveChanges();
                MessageBox.Show("Сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения предмета");
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
            Navigation.GoBack();
        }


    }
}
