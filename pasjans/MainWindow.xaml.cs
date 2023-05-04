using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        public ObservableCollection<int> tabValue { get; set; }
        public ObservableCollection<ObservableCollection<Card>> tabliaZbior { get; set; }
        public int iloscRozdan;
        public int IloscKard;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            tabValue = new ObservableCollection<int>();
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
            tabliaZbior = new ObservableCollection<ObservableCollection<Card>>();
            taliaPod = new ObservableCollection<int>();
            int IloscKard;
            int iloscRozdan;

        }
        private object firstSelectedCard = null;
        private object secondSelectedCard = null;

        private void Button_Card_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var card = button.DataContext as Card;


            card.IsChecked = !card.IsChecked;

            if (card.isOdw == true && card.IsChecked == true)
            {
                     
                if(tabValue.Count() == 0)
                {
                    firstSelectedCard = card.naztali;
                }
                if (tabValue.Count() <= 1)
                {
                    secondSelectedCard = card.naztali;
                    tabValue.Add(card.Value);
                    button.BorderThickness = new Thickness(3);
                    button.BorderBrush = Brushes.Red;
                    if (tabValue.Count() == 2)
                    {
                        if (tabValue[0] - 1 == tabValue[1])
                        {
                            var i = 0;
                            var k = 0;
                            while (secondSelectedCard != tabliaZbior[i] )
                            {if (i != 9)
                                {
                                    i++;
                                }else
                                {
                                    MessageBox.Show("blond i");
                                }
                            }
                            while (firstSelectedCard != tabliaZbior[k])
                            {
                                if (k != 9)
                                {
                                    k++;
                                }
                                else
                                {
                                    MessageBox.Show("blond k");
                                }
                            }
                           
                                tabliaZbior[k].Add(tabliaZbior[i][tabliaZbior[i].Count() - 1]);
                                tabliaZbior[i].Remove(tabliaZbior[i][tabliaZbior[i].Count() - 1]);
                            card.naztali = firstSelectedCard;
                            OdwrocKarte(tabliaZbior[i]);
                                button.BorderBrush = Brushes.DarkBlue;
                                tabValue.Clear();
                            
                        }
                     
                    }
                }
                else
                {//usuwanie jak za duzo
                    card.IsChecked = false;
                    button.BorderThickness = new Thickness(0);

                    button.BorderThickness = new Thickness(3);

                     button.BorderBrush = Brushes.Red;
                    
                    tabValue.Remove(tabValue[0]);
                    tabValue.Add(card.Value);

                }

            }
            else
            {

                //MessageBox.Show(tabValue.Count().ToString() + ", " + tabValue[0] + "abba");
                tabValue.Remove(card.Value);
                button.BorderThickness = new Thickness(0);
               // firstSelectedCard = null;

            }

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
                            tabValue.Clear();
            iloscRozdan = 0;
            newkard.IsEnabled = true;
            IloscKard = 104;
            RozdajKartyOdwrot(5);
            tabliaZbior.Add(talia);
            tabliaZbior.Add(talia2);
            tabliaZbior.Add(talia3);
            tabliaZbior.Add(talia4);
            tabliaZbior.Add(talia5);
            tabliaZbior.Add(talia6);
            tabliaZbior.Add(talia7);
            tabliaZbior.Add(talia8);
            tabliaZbior.Add(talia9);
            tabliaZbior.Add(talia10);
      

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
                talia.Add(new Card(talia));
                talia2.Add(new Card(talia2));
                talia3.Add(new Card(talia3));
                talia4.Add(new Card(talia4));

            }
            for (int i = 0; i < x - 1; i++)
            {
                talia5.Add(new Card(talia5));
                talia6.Add(new Card(talia6));
                talia7.Add(new Card(talia7));
                talia8.Add(new Card(talia8));
                talia9.Add(new Card(talia9));
                talia10.Add(new Card(talia10));

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
            if(tal.Count() == 0) {
            tal.Add(new Card(tal));
                tal[0] = new Card(tal) { Value = 14, isOdw = true };
            }else
            {
                int lastIndex = tal.Count - 1;
                var random = new Random();
                int x = random.Next(0, IloscKard);
                int a = taliaPod[x];
                tal[lastIndex] = new Card(tal) { Value = a, isOdw = true };
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
                for (int i = 0; i <= 14; i++)
                {

                }

                talia.Add(new Card(talia));
            talia2.Add(new Card(talia2));
            talia3.Add(new Card(talia3));
            talia4.Add(new Card(talia4));
            talia5.Add(new Card(talia5));
            talia6.Add(new Card(talia6));
            talia7.Add(new Card(talia7));
            talia8.Add(new Card(talia8));
            talia9.Add(new Card(talia9));
            talia10.Add(new Card(talia10));
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
            if (iloscRozdan == 5)   newkard.IsEnabled = false;

            } }
        private void IfWin()
        {

        }

        private void Ruch()
        {
            }
        }
    }

