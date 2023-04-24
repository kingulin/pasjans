using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasjans
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private bool _isButton1Selected;
        private bool _isButton2Selected;

        public bool IsButton1Selected
        {
            get => _isButton1Selected;
            set
            {
                if (value)
                {
                    IsButton2Selected = false;
                }
             //   SetProperty(ref _isButton1Selected, value);
            }
        }

        public bool IsButton2Selected
        {
            get => _isButton2Selected;
            set
            {
                if (value)
                {
                    IsButton1Selected = false;
                }
              //  SetProperty(ref _isButton2Selected, value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
