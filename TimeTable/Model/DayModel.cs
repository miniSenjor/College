using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Model
{
    public class DayModel
    {
        public string DayName { get; set; } // Например, "Понедельник", "Вторник"
        public List<LessonModel> Lessons { get; set; }
    }
}
