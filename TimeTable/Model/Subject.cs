using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable
{
    public partial class Subject
    {
        public string SubjectNameAndTeacher => Teacher.FIO +" "  +SubjectName.name;
    }
}
