using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace pasjans
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Card> talia { get; set; }
        public ObservableCollection<Card> talia2 { get; set; }
        public ObservableCollection<Card> talia3 { get; set; }
        public ObservableCollection<Card> talia4 { get; set; }
        public ObservableCollection<Card> talia5 { get; set; }
        public ObservableCollection<Card> talia6 { get; set; }
        public ObservableCollection<Card> talia7 { get; set; }
        public ObservableCollection<Card> talia8 { get; set; }
        public ObservableCollection<Card> talia9 { get; set; }
        public ObservableCollection<Card> talia10 { get; set; }
        public ObservableCollection<int> taliaPod { get; set; }
        public int iloscRozdan;
        public int IloscKard { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            talia = new ObservableCollection<Card>();
            talia2 = new ObservableCollection<Card>();
            talia3 = new ObservableCollection<Card>();
            talia4 = new ObservableCollection<Card>();
            talia5 = new ObservableCollection<Card>();
            talia6 = new ObservableCollection<Card>();
            talia7 = new ObservableCollection<Card>();
            talia8 = new ObservableCollection<Card>();
            talia9 = new ObservableCollection<Card>();
            talia10 = new ObservableCollection<Card>();
            taliaPod = new ObservableCollection<int>();
            IloscKard = 104;
            int iloscRozdan = 0;

        }


        private void Button_Card_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var card = button.DataContext as Card;
            card.IsSelected = !card.IsSelected;
        }

        private void TasujKarty()
        {

            taliaPod.Clear();
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    taliaPod.Add(i);
                }
            }
        }
        private void RozdajKarty(object sender, RoutedEventArgs e)
        {
            RozdajKartyOdwrot(3);

        }
        private void RozdajKartyOdwrot(int x)
        {
            talia.Clear();
            talia2.Clear();
            talia3.Clear();
            talia4.Clear();
            talia5.Clear();
            talia6.Clear();
            talia7.Clear();
            talia8.Clear();
            talia9.Clear();
            talia10.Clear();
            for (int i = 0; i < x; i++)
            {
                talia.Add(new Card(0, 20));
                talia2.Add(new Card(0, 20));
                talia3.Add(new Card(0, 20));
                talia4.Add(new Card(0, 20));

            }
            for (int i = 0; i < x - 1; i++)
            {
                talia5.Add(new Card(0, 20));
                talia6.Add(new Card(0, 20));
                talia7.Add(new Card(0, 20));
                talia8.Add(new Card(0, 20));
                talia9.Add(new Card(0, 20));
                talia10.Add(new Card(0, 20));

            }
            TasujKarty();
            OdwrocKarte(talia);
            OdwrocKarte(talia2);
            OdwrocKarte(talia3);
            OdwrocKarte(talia4);
            OdwrocKarte(talia5);
            OdwrocKarte(talia6);
            OdwrocKarte(talia7);
            OdwrocKarte(talia8);
            OdwrocKarte(talia9);
            OdwrocKarte(talia10);
        }

        private void OdwrocKarte(ObservableCollection<Card> tal)
        {
            if (taliaPod.Count() == 0)
            {
                MessageBox.Show("Najpierw zacznij gre!", "Zacznij Gre", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int lastIndex = tal.Count - 1;
                var random = new Random();
                int x = random.Next(0, IloscKard);
                int a = taliaPod[x];
                tal[lastIndex] = new Card(0, 20) { Value = a };
                taliaPod.RemoveAt(x);
                IloscKard--;
            }
        }


        private void Kupka(object sender, RoutedEventArgs e)
        {
            if (taliaPod.Count() == 0)
            {
                MessageBox.Show("Najpierw zacznij gre!", "Zacznij Gre", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
            
            talia.Add(new Card(0, 20));
            talia2.Add(new Card(0, 20));
            talia3.Add(new Card(0, 20));
            talia4.Add(new Card(0, 20));
            talia5.Add(new Card(0, 20));
            talia6.Add(new Card(0, 20));
            talia7.Add(new Card(0, 20));
            talia8.Add(new Card(0, 20));
            talia9.Add(new Card(0, 20));
            talia10.Add(new Card(0, 20));
            OdwrocKarte(talia);
            OdwrocKarte(talia2);
            OdwrocKarte(talia3);
            OdwrocKarte(talia4);
            OdwrocKarte(talia5);
            OdwrocKarte(talia6);
            OdwrocKarte(talia7);
            OdwrocKarte(talia8);
            OdwrocKarte(talia9);
            OdwrocKarte(talia10);
            iloscRozdan++;
                
                if(iloscRozdan == 5)   newkard.IsEnabled = false;

            } }
        private void IfWin()
        {

        }

        private void Ruch()
        {

        }
    }
}
