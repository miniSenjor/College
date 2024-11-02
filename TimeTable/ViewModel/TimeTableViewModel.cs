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
            /*Weeks = new ObservableCollection<WeekModel>();
            WeekModel week = new WeekModel();
            week.GroupName = "dfsg";
            List<DayModel> days = new List<DayModel>();
            List<LessonModel> les = new List<LessonModel>();
            days.Add(new DayModel { DayName = "Понедельник", Lessons = les });
            week.Days = days;
            Weeks.Add(week);*/

            var groups = App.GetContext().Group.ToList(); // Получаем все группы в память

            Weeks = new ObservableCollection<WeekModel>(
            groups.Select(g => new WeekModel
            {
                GroupName = g.name,
                Days = new List<DayModel>
                {
                    new DayModel { DayName = "Понедельник", Lessons = GetLessonsForDay(g.id_group, 1, groups) },
                    new DayModel { DayName = "Вторник", Lessons = GetLessonsForDay(g.id_group, 2, groups) },
                    new DayModel { DayName = "Среда", Lessons = GetLessonsForDay(g.id_group, 3, groups) },
                    new DayModel { DayName = "Четверг", Lessons = GetLessonsForDay(g.id_group, 4, groups) },
                    new DayModel { DayName = "Пятница", Lessons = GetLessonsForDay(g.id_group, 5, groups) },
                    new DayModel { DayName = "Суббота", Lessons = GetLessonsForDay(g.id_group, 6, groups) }
                }
            }).ToList());
        }

        private List<LessonModel> GetLessonsForDay(int groupId, int dayOfWeek, List<Group> allGroups)
        {
            return App.GetContext().Subject
                .Where(s => s.id_group == groupId)
                .SelectMany(s => s.Lesson
                    .Where(l => l.day == dayOfWeek)
                    .Select(l => new LessonModel
                    {
                        Subject = s.SubjectName.name,
                        Teacher = s.Teacher.FIO,
                        Cabinet = l.Сabinet.number,
                        Number = l.number
                    }))
                .ToList();
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

}
