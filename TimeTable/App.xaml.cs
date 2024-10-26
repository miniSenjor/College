using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TimeTable
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static TimeTableEntities _context;

        public static TimeTableEntities GetContext()
        {
            if (_context == null)
                _context = new TimeTableEntities();
            return _context;
        }
    }
}
