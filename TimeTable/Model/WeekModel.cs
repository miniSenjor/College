using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Model
{
    public class WeekModel
    {
        public string GroupName { get; set; }
        public List<DayModel> Days { get; set; }
    }
}
