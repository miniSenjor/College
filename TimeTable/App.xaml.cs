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
    /// Логика взаимодействия для App.xaml.
    /// Здесь только инициализация контекста
    /// <inheritdoc/>
    /// <code>
    /// Field _context - хранит в себе контекст экземпляра класса БД
    /// Method GetContext() - создает экземпяр класса для контекста
    /// </code>
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
