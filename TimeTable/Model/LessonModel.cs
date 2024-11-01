using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Model
{
    public class LessonModel
    {
        public int Number {  get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public int Cabinet { get; set; }
    }
}
