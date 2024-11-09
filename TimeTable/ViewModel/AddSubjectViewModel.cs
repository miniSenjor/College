using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimeTable.ViewModel
{
    internal class AddSubjectViewModel
    {
        //без гет сет ошибка привязки данных через биндинг
        public ObservableCollection<SubjectName> Subjects { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public Subject CurrentSubject { get; set; }
        private TimeTableEntities _context;

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
        public AddSubjectViewModel()
        {
            _context = App.GetContext();
            LoadData();
            //LstSubjectName.AddRange(_context.SubjectName.Select(s => s.name).ToList());
        }

        private async void LoadData()
        {
            Subjects = new ObservableCollection<SubjectName>(_context.SubjectName.ToList());
            Teachers = new ObservableCollection<Teacher>(_context.Teacher.ToList());
            Groups = new ObservableCollection<Group>(_context.Group.ToList());
        }

        private void CreateNewSubject(object obj)
        {
            if  (CurrentSubject == null)
            {
                MessageBox.Show("Не выбраны поля для создания Предмета");
            }
            MessageBox.Show(CurrentSubject.Teacher.ToString());
        }
    }
}
