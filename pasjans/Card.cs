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
        private bool _IsSelected;
        private  int _y;
        private  int _z;

        public Card(int y, int z)
        {
            _y = y;
            _z = z;
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
  

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
