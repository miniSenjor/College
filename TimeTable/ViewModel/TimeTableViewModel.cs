using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Model;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    public class TimeTableViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<WeekModel> Weeks { get; set; }

        public TimeTableViewModel()
        {
            LoadData();
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


        /// <summary>
        /// Метод подгрузки данных
        /// <code>Method LoadData()</code>
        /// </summary>
        private void LoadData()
        {
            // Выполняем JOIN запрос, чтобы получить все необходимые данные в одном запросе
            var query = from g in App.GetContext().Group
                        join s in App.GetContext().Subject on g.id_group equals s.id_group
                        join l in App.GetContext().Lesson on s.id_subject equals l.id_subject
                        join t in App.GetContext().Teacher on s.id_teacher equals t.id_teacher
                        join c in App.GetContext().Сabinet on l.id_cabinet equals c.id_cabinet
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
                            }).ToList()
                    }).ToList()
                }).ToList();

            // Обновляем коллекцию Weeks
            Weeks = new ObservableCollection<WeekModel>(groupedData);
        }

        private string GetDayName(int dayOfWeek)
        {
            if (dayOfWeek == 1)
                return "Понедельник";
            else if (dayOfWeek == 2)
                return "Вторник";
            else if (dayOfWeek == 3)
                return "Среда";
            else if (dayOfWeek == 4)
                return "Четверг";
            else if (dayOfWeek == 5)
                return "Пятница";
            else if (dayOfWeek == 6)
                return "Суббота";
            else
                throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Неверный номер дня недели");
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

}
