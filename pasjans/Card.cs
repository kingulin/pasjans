using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasjans
{
  public  class Card : INotifyPropertyChanged
    {
        private int _value;
        public bool isOdw = false;
        private bool _IsSelected;
        private bool isChecked;
        public bool IsChecked
    {
        get { return isChecked; }
        set
        {
            isChecked = value;
            OnPropertyChanged("IsChecked");
        }
    }
        protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                _IsSelected = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                }

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
