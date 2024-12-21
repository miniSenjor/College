using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeTable.View;

namespace TimeTable.ViewModel
{
    internal class AddCabinetViewModel : INotifyPropertyChanged
    {
        public AddCabinetViewModel() 
        {
            _context = App.GetContext();
            Cabinet = new Сabinet();
            Cabinets = new ObservableCollection<Сabinet>(_context.Сabinet);
        }
        private TimeTableEntities _context;
        private Сabinet _cabinet;
        public Сabinet Cabinet
        {
            get => _cabinet;
            set => SetField(ref _cabinet, value);
        }
        private ObservableCollection<Сabinet> _cabinets;
        public ObservableCollection<Сabinet> Cabinets
        {
            get => _cabinets;
            set => SetField(ref _cabinets, value);
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

        private RelayCommand _newCabinetCommand;
        public RelayCommand NewCabinetCommand
        {
            get
            {
                if (_newCabinetCommand == null)
                    _newCabinetCommand = new RelayCommand(NewCabinet);
                return _newCabinetCommand;
            }
        }

        private void NewCabinet(object obj)
        {
            MessageBox.Show(Cabinet.number.ToString());
            Navigation.Navigate(new AddCabinetView());
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
            _context.Сabinet.AddOrUpdate(Cabinet);
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
