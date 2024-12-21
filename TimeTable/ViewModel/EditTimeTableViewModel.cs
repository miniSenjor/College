using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeTable.Model;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    internal class EditTimeTableViewModel
    {
        public EditTimeTableViewModel(ObservableCollection<WeekModel> weekModels=null) 
        {
            _context = App.GetContext();
            Groups = new ObservableCollection<Group>(_context.Group);
            if (weekModels != null ) 
            {
                Weeks = weekModels;   
            }
            else
            {
                Weeks = new ObservableCollection<WeekModel>();
            }
            Cabinets = new ObservableCollection<Сabinet>(_context.Сabinet);
            Subjects = new ObservableCollection<Subject>(_context.Subject);
        }
        private TimeTableEntities _context;
        private Group _group;
        public Group Group
        {
            get => _group;
            set => SetField(ref _group, value);
            /*{ 
                if (SetField(ref _group, value))
                {
                    GroupSelectedCanged(_group);
                }

                //MessageBox.Show(_group.name);
            }*/
        }
        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => SetField(ref _groups, value);
        }
        private ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set => SetField(ref _subjects, value);
        }
        private ObservableCollection<WeekModel> _weeks;
        public ObservableCollection<WeekModel> Weeks
        {
            get => _weeks;
            set => SetField(ref _weeks, value);
        }
        private Lesson _selectedLesson;
        public Lesson SelectedLesson
        {
            get => _selectedLesson;
            set => SetField(ref _selectedLesson, value);
        }
        private ObservableCollection<Сabinet> _cabinets;
        public ObservableCollection<Сabinet> Cabinets
        {
            get => _cabinets;
            set => SetField(ref _cabinets, value);
        }
        private bool SetField<T>(ref T field, T newValue)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(nameof(field));
                if (field is Group)
                    GroupSelectedCanged(Group);
                return true;
            }
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void SaveSelectedSubject(object obj)
        {
            Navigation.GoBack();
        }

        private void GroupSelectedCanged(Group group)
        {
            var groupId = group.id_group; // Замените это на id вашей группы

            var query = from g in App.GetContext().Group
                        join s in App.GetContext().Subject on g.id_group equals s.id_group
                        join l in App.GetContext().Lesson on s.id_subject equals l.id_subject
                        join t in App.GetContext().Teacher on s.id_teacher equals t.id_teacher
                        join c in App.GetContext().Сabinet on l.id_cabinet equals c.id_cabinet
                        where g.id_group == groupId  // Фильтруем по id группы
                        select new
                        {
                            GroupId = g.id_group,
                            GroupName = g.name,
                            SubjectName = s.SubjectName.name,
                            TeacherName = t.FIO,
                            CabinetNumber = c.number,
                            LessonNumber = l.number,
                            DayOfWeek = l.day
                        };

            // Группируем данные по группе и дню недели
            var groupedData = query.ToList()
                .GroupBy(x => new { x.GroupId, x.GroupName })
                .Select(g => new WeekModel
                {
                    GroupName = g.Key.GroupName,
                    Days = Enumerable.Range(1, 6).Select(dayOfWeek => new DayModel
                    {
                        DayName = GetDayName(dayOfWeek),
                        Lessons = g.Where(x => x.DayOfWeek == dayOfWeek)
                            .Select(x => new LessonModel
                            {
                                Subject = x.SubjectName,
                                Teacher = x.TeacherName,
                                Cabinet = x.CabinetNumber,
                                Number = x.LessonNumber
                            }).OrderBy(lesson => lesson.Number) // Сортируем по номеру урока
                            .ToList()
                    }).ToList()
                }).ToList();

            // Обновляем коллекцию Weeks
            Weeks = new ObservableCollection<WeekModel>(groupedData);
            Navigation.Navigate(new EditTimeTableView(Weeks));
        }

        private string GetDayName(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 1:
                    return "Понедельник";
                case 2:
                    return "Вторник";
                case 3:
                    return "Среда";
                case 4:
                    return "Четверг";
                case 5:
                    return "Пятница";
                case 6:
                    return "Суббота";
                default:
                    throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Неверный номер дня недели"); ;
            }
        }
    }
}
