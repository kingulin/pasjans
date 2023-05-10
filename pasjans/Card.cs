using System.Collections.ObjectModel;
using System.ComponentModel;

namespace pasjans
{
    public class Card : INotifyPropertyChanged
    {
        private int _value;
        public bool isOdw = false;
        private bool _IsSelected;

        public ObservableCollection<Card> Talia { get; set; }
        public int naztali;

        public Card(int naztali)
        {
            this.naztali = naztali;
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
