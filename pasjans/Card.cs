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
        private static int _y;
        private static int _z;
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
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
                }
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
