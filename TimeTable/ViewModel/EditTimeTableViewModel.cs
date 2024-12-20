using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeTable.Model;

namespace TimeTable.ViewModel
{
    internal class EditTimeTableViewModel
    {
        public EditTimeTableViewModel() 
        {
            _context = App.GetContext();
            Groups = new ObservableCollection<Group>(_context.Group);
            Weeks = new ObservableCollection<WeekModel>();
        }
        private TimeTableEntities _context;
        private Group _group;
        public Group Group
        {
            get => _group;
            set 
            { 
                if (SetField(ref _group, value))
                {
                    
                }


            }
        }
        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => SetField(ref _groups, value);
        }
        private ObservableCollection<WeekModel> _weeks;
        public ObservableCollection<WeekModel> Weeks
        {
            get => _weeks;
            set => SetField(ref _weeks, value);
        }
        private bool SetField<T>(ref T field, T newValue)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(nameof(field));
                return true;
            }
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /*private RelayCommand _groupSelectedCangedCommandCommand;
        public RelayCommand GroupSelectedCangedCommand
        {
            get
            {
                if (_groupSelectedCangedCommandCommand == null)
                    _groupSelectedCangedCommandCommand = new RelayCommand(GroupSelectedCangedCommandCommand);
                return _groupSelectedCangedCommandCommand;
            }
        }*/
        private void GroupSelectedCanged(Group Group)
        {
            //Weeks
        }
    }
}
