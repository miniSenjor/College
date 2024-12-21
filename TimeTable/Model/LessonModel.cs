using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Model
{
    public class LessonModel
    {
        public int Number { get; set; }
        public Subject Subject { get; set; }
        public string Teacher { get; set; }
        public Сabinet Cabinet { get; set; }

        public string SubjectName { get; set; }
        public int CabinetName { get; set; }


        public ObservableCollection<Subject> ListSubjects{ get => new ObservableCollection<Subject>(App.GetContext().Subject); }
        public ObservableCollection<Сabinet> ListCabinets{ get => new ObservableCollection<Сabinet>(App.GetContext().Сabinet); }

    }
}
