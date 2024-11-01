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

        private void LoadData()
        {
            Weeks = new ObservableCollection<WeekModel>(
            App.GetContext().Group.Select(g => new WeekModel
            {
                GroupName = g.name,
                Days = new List<DayModel>
                {//Какая-то ошибка LINQ
                    new DayModel { DayName = "Понедельник", Lessons = GetLessonsForDay(g.id_group, 1) },
                    new DayModel { DayName = "Вторник", Lessons = GetLessonsForDay(g.id_group, 2) },
                    new DayModel { DayName = "Среда", Lessons = GetLessonsForDay(g.id_group, 3) },
                    new DayModel { DayName = "Четверг", Lessons = GetLessonsForDay(g.id_group, 4) },
                    new DayModel { DayName = "Пятница", Lessons = GetLessonsForDay(g.id_group, 5) },
                    new DayModel { DayName = "Суббота", Lessons = GetLessonsForDay(g.id_group, 6) }
                }
            }).ToList());
        }

        private List<LessonModel> GetLessonsForDay(int groupId, int dayOfWeek)
        {
            return App.GetContext().Subject
                .Where(s => s.id_group == groupId)
                .SelectMany(s => s.Lesson
                    .Where(l => l.day == dayOfWeek) // Фильтрация по дню недели
                    .Select(l => new LessonModel
                    {
                        Subject = s.SubjectName.name,
                        Teacher = s.Teacher.FIO,
                        Cabinet = l.Сabinet.number,
                        Number = l.number // Используем свойство number из Lesson
                    })
                ).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
