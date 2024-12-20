using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimeTable.ViewModel
{
    internal class AddCabinetViewModel : INotifyPropertyChanged
    {
        public AddCabinetViewModel() 
        {
            _context = App.GetContext();
            Cabinet = new Сabinet();
            _context.Сabinet.Add(Cabinet);
        }
        private TimeTableEntities _context;
        private Сabinet _cabinet;
        public Сabinet Cabinet
        {
            get => _cabinet;
            set => SetField(ref _cabinet, value);
        }
        private void SetField<T>(ref T field, T newValue)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(nameof(field));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(Save);
                return _saveCommand;
            }
        }

        private void Save(object obj)
        {
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Кабинет успешно добавлен!");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private RelayCommand _backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new RelayCommand(Back);
                return _backCommand;
            }
        }

        private void Back(object obj)
        {
            Navigation.GoBack();
        }
    }
}
