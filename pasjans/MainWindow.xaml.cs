using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        private ObservableCollection<int> _collection = new ObservableCollection<int>();

        public ObservableCollection<ObservableCollection<Card>> tabliaZbior { get; set; }
        public int iloscRozdan;
        public Card cards;
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
        private Card firstSelectedCard;
        private Button firstSelectedButton;
        private Card secondSelectedCard;
        private Button secondSelectedButton;


        private void Button_Card_Click(object sender, RoutedEventArgs e)
        {
            //CreateObservableCollection();
            var button = sender as Button;
            var card = button.DataContext as Card;


            card.IsChecked = !card.IsChecked;

            if (card.isOdw == true && card.IsChecked == true)
            {
                ObservableCollection<Card> curTalia = tabliaZbior[card.naztali];
                // if(tabValue.Count() == 0)
                if (firstSelectedCard == null && curTalia.ElementAt(curTalia.Count() - 1) == card)
                {
                    firstSelectedButton = button;
                    firstSelectedCard = card;
                    button.BorderThickness = new Thickness(3);
                    button.BorderBrush = Brushes.Yellow;
                }
                else if (firstSelectedCard != null)
                {
                    secondSelectedButton = button;
                    secondSelectedCard = card;
                    //tabValue.Add(card.Value);
                    button.BorderThickness = new Thickness(3);
                    button.BorderBrush = Brushes.Red;
                }
                if (firstSelectedCard != null && secondSelectedCard != null)
                {
                    if (firstSelectedCard.Value - 1 == secondSelectedCard.Value || firstSelectedCard.Value == 14)
                    {
                        if (firstSelectedCard.Value == 14)
                        {
                            tabliaZbior[0].Remove(tabliaZbior[0][0]);

                        }
                        var i = 0;
                        var k = 0;
                        while (tabliaZbior[secondSelectedCard.naztali] != tabliaZbior[i])
                        {
                            if (i != 9)
                            {
                                i++;
                            }
                            else
                            {
                                MessageBox.Show("blond i");
                            }
                        }
                        while (tabliaZbior[firstSelectedCard.naztali] != tabliaZbior[k])
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
                        //card.naztali = firstSelectedCard;
                        OdwrocKarte(i);

                    }

                    firstSelectedButton.BorderThickness = new Thickness(0); ;
                    secondSelectedButton.BorderThickness = new Thickness(0);
                    firstSelectedCard = null;
                    secondSelectedCard = null;
                }
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
            RozdajKartyOdwrot(5);


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
                talia.Add(new Card(0));
                talia2.Add(new Card(1));
                talia3.Add(new Card(2));
                talia4.Add(new Card(3));

            }
            for (int i = 0; i < x - 1; i++)
            {
                talia5.Add(new Card(4));
                talia6.Add(new Card(5));
                talia7.Add(new Card(6));
                talia8.Add(new Card(7));
                talia9.Add(new Card(8));
                talia10.Add(new Card(9));

            }
            TasujKarty();
            OdwrocKarte(0);
            OdwrocKarte(1);
            OdwrocKarte(2);
            OdwrocKarte(3);
            OdwrocKarte(4);
            OdwrocKarte(5);
            OdwrocKarte(6);
            OdwrocKarte(7);
            OdwrocKarte(8);
            OdwrocKarte(9);
        }

        private void OdwrocKarte(int tal)
        {

            if (taliaPod.Count() == 0)
            {
                MessageBox.Show("Najpierw zacznij gre!", "Zacznij Gre", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            if (tabliaZbior[tal].Count() == 0)
            {
                tabliaZbior[tal].Add(new Card(tal));
                tabliaZbior[tal][0] = new Card(tal) { Value = 14, isOdw = true };
            }
            else
            {
                int lastIndex = tabliaZbior[tal].Count - 1;
                var random = new Random();
                int x = random.Next(0, IloscKard);
                int a = taliaPod[x];
                tabliaZbior[tal][lastIndex] = new Card(tal) { Value = a, isOdw = true };
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

                talia.Add(new Card(0));
                talia2.Add(new Card(1));
                talia3.Add(new Card(2));
                talia4.Add(new Card(3));
                talia5.Add(new Card(4));
                talia6.Add(new Card(5));
                talia7.Add(new Card(6));
                talia8.Add(new Card(7));
                talia9.Add(new Card(8));
                talia10.Add(new Card(9));
                OdwrocKarte(0);
                OdwrocKarte(1);
                OdwrocKarte(2);
                OdwrocKarte(3);
                OdwrocKarte(4);
                OdwrocKarte(5);
                OdwrocKarte(6);
                OdwrocKarte(7);
                OdwrocKarte(8);
                OdwrocKarte(9);
                iloscRozdan++;
                if (iloscRozdan == 5) newkard.IsEnabled = false;

            }
        }
        private void IfWin()
        {

        }


    }


}

