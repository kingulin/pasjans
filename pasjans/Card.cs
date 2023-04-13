using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasjans
{
    class Card
    {
        private int _valueOfCard;
        private bool _IsSelected;
        public int Value
        {
            get => _valueOfCard;
            set
            {
                _valueOfCard = value;
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
