using System.ComponentModel;

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
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
