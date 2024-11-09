﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TimeTable.ViewModel
{
    /// <summary>
    /// Класс для навигации в приложении между страницами
    /// </summary>
    public class Navigation
    {
        private static Frame _mainFrame;

        /// <summary>
        /// Иницилизировали методом страницу
        /// </summary>
        /// <param name="mainFrame"></param>
        public static void Initialize(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }
        /// <summary>
        /// Иницируем страницу куда хотим перейти
        /// </summary>
        /// <param name="page"></param>

        /// <summary>
        /// Переход на новую страницу
        /// </summary>
        /// <param name="page">Новая страница</param>
        public static void Navigate(Page page)
        {
            _mainFrame.Content = page;
        }

        /// <summary>
        /// Серегин кастом метод для перехода назад на прошлую страницу
        /// </summary>
        public static void GoBack()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }
    }
}
