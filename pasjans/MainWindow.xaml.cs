using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

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

        public Image[] takes;

        private ObservableCollection<Card> collection = new ObservableCollection<Card>();

        public ObservableCollection<ObservableCollection<Card>> taliaZbior { get; set; }
        public int iloscRozdan;
        public Card cards;
        public int IloscKard;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            timer.Tick += Timer_Tick;
            takes = new Image[] { take1, take2, take3, take4, take5, take6, take7, take8 };
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
            taliaZbior = new ObservableCollection<ObservableCollection<Card>>();
            taliaPod = new ObservableCollection<int>();
            int IloscKard;
            int iloscRozdan;
            int ProgressToEndGame; timer.Interval = TimeSpan.FromMilliseconds(1000);


        }
        private Card firstSelectedCard;
        private Button firstSelectedButton;
        private Card secondSelectedCard;
        private Button secondSelectedButton;
        int MakeVisilbe = 0;
        int FittingCartsInColumn = 1;
        int ProgressToEndGame = 0;
        int counter = 0;

        private void Button_Card_Click(object sender, RoutedEventArgs e)
        {
            //CreateObservableCollection();
            var button = sender as Button;
            var card = button.DataContext as Card;

            if (card.isOdw == true)
            {
                ObservableCollection<Card> curTalia = taliaZbior[card.naztali];
                // if(tabValue.Count() == 0)
                if (firstSelectedCard == null && curTalia.ElementAt(curTalia.Count() - 1) == card)
                {
                    firstSelectedButton = button;
                    firstSelectedCard = card;
                    button.BorderThickness = new Thickness(3);
                    button.BorderBrush = Brushes.Red;
                }
                else if (firstSelectedCard != null)
                {
                    int WybCardVal = 0;
                    collection.Clear();
                    for (int i = 0; i < curTalia.Count(); i++)
                    {

                        if (WybCardVal > 0)
                        {
                            if (WybCardVal - 1 == curTalia[i].Value)
                            {

                                collection.Add(curTalia[i]);
                                //MessageBox.Show(curTalia[i].Value.ToString() + ", " + i);
                                WybCardVal--;
                            }
                            else
                            {
                                collection.Clear();
                                WybCardVal = 0;
                            }
                        }
                        if (curTalia[i] == card)
                        {
                            //    MessageBox.Show(card.Value.ToString() + ", " + i);
                            WybCardVal = card.Value;
                            collection.Add(card);
                        }

                    }
                    if (collection.Count() > 0)
                    {
                        for (int i = 0; i < collection.Count(); i++)
                        {
                            //   MessageBox.Show(collection[i].Value.ToString());
                        }
                        secondSelectedButton = button;
                        secondSelectedCard = card;
                        //tabValue.Add(card.Value);
                        button.BorderThickness = new Thickness(3);
                        button.BorderBrush = Brushes.Red;
                    }
                }
                if (firstSelectedCard != null && secondSelectedCard != null)
                {
                    if (firstSelectedCard.Value - 1 == secondSelectedCard.Value || firstSelectedCard.Value == 14)
                    {
                        if (firstSelectedCard.Value == 14)
                        {
                            taliaZbior[firstSelectedCard.naztali].RemoveAt(0);

                        }
                        var first = firstSelectedCard.naztali;
                        var second = secondSelectedCard.naztali;

                        for (int i = 0; i < collection.Count(); i++)
                        {

                            taliaZbior[second].Remove(collection[i]);
                            collection[i].naztali = first;
                            taliaZbior[first].Add(collection[i]);
                        }
                        IfKupkaPelna(talia);
                        IfKupkaPelna(talia2);
                        IfKupkaPelna(talia3);
                        IfKupkaPelna(talia4);
                        IfKupkaPelna(talia5);
                        IfKupkaPelna(talia6);
                        IfKupkaPelna(talia7);
                        IfKupkaPelna(talia8);
                        IfKupkaPelna(talia9);
                        IfKupkaPelna(talia10);

                        OdwrocKarte(second);
                        OdwrocKarte(first);


                    }

                    firstSelectedButton.BorderThickness = new Thickness(0);
                    secondSelectedButton.BorderThickness = new Thickness(0);
                    firstSelectedCard = null;
                    secondSelectedCard = null;
                    // MessageBox.Show(collection.Count().ToString());

                }

            }
        }

        private void IfKupkaPelna(ObservableCollection<Card> talia)
        {
            int CardToRemove = 0;
            if (talia.Count() >= 13)
            {
                FittingCartsInColumn = 1;
                for (int i = 1; i < talia.Count(); i++)
                {
                    CardToRemove = i;
                    if (talia[i - 1].Value == talia[i].Value + 1)
                    {
                        FittingCartsInColumn++;
                        if (FittingCartsInColumn == 13)
                        {
                            for (int j = CardToRemove; j > CardToRemove - 13; j--)
                            {
                                talia.RemoveAt(j);
                            }
                            takes[MakeVisilbe].Visibility = Visibility.Visible;
                            MakeVisilbe += 1;
                            FittingCartsInColumn = 1;
                            ProgressToEndGame += 1;
                            if (ProgressToEndGame == 1)
                            {
                                timer.Stop();

                                TimeSpan timeElapsed = TimeSpan.FromSeconds(counter);
                                string times = string.Format("{0:D2}:{1:D2}", timeElapsed.Minutes, timeElapsed.Seconds);

                                MessageBoxResult result = MessageBox.Show("Gratulacje! \n Wygrałeś grę! \n twój czas to: " + times + "\n chcesz zagrać jeszcze raz?", "Wygrana!", MessageBoxButton.YesNo, MessageBoxImage.Warning);


                                if (result == MessageBoxResult.Yes)
                                {
                                    RozdajKarty();
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        FittingCartsInColumn = 1;
                    }
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
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            TimeSpan timeElapsed = TimeSpan.FromSeconds(counter);
            time.Text = string.Format("{0:D2}:{1:D2}", timeElapsed.Minutes, timeElapsed.Seconds);

        }
        private void RozdajKartyButt(object sender, RoutedEventArgs e)
        {
            RozdajKarty();
        }
        private void RozdajKarty()
        {
            counter = 0;
            timer.Start();
            ProgressToEndGame = 0;
            tabValue.Clear();
            iloscRozdan = 0;
            newkard.IsEnabled = true;
            IloscKard = 104;
            taliaZbior.Add(talia);
            taliaZbior.Add(talia2);
            taliaZbior.Add(talia3);
            taliaZbior.Add(talia4);
            taliaZbior.Add(talia5);
            taliaZbior.Add(talia6);
            taliaZbior.Add(talia7);
            taliaZbior.Add(talia8);
            taliaZbior.Add(talia9);
            taliaZbior.Add(talia10);
            RozdajKartyOdwrot(6);
            if (MakeVisilbe > 0)
            {
                for (int i = 0; i <= 7; i++)
                {
                    takes[i].Visibility = Visibility.Hidden;
                }

                MakeVisilbe = 0;
            }


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

            //  if (taliaPod.Count() == 0)
            // {
            //        MessageBox.Show("Najpierw zacznij gre!", "Zacznij Gre", MessageBoxButton.OK, MessageBoxImage.Warning);
            //   }
            //  else
            if (taliaZbior[tal].Count() == 0)
            {
                taliaZbior[tal].Add(new Card(tal));
                taliaZbior[tal][0] = new Card(tal) { Value = 14, isOdw = true };
            }
            else
            {
                int lastIndex = taliaZbior[tal].Count - 1;
                if (taliaZbior[tal][lastIndex].isOdw == false)
                {
                    var random = new Random();
                    int x = random.Next(0, IloscKard);
                    int a = taliaPod[x];
                    taliaZbior[tal][lastIndex] = new Card(tal) { Value = a, isOdw = true };
                    taliaPod.RemoveAt(x);
                    IloscKard--;
                }
            }
        }


        private void Kupka(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < taliaZbior.Count(); j++)
            {
                if (taliaZbior[j][0].Value == 14)
                {
                    MessageBox.Show("Masz puste pola!", "Puste pola", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
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
                IfKupkaPelna(talia);
                IfKupkaPelna(talia2);
                IfKupkaPelna(talia3);
                IfKupkaPelna(talia4);
                IfKupkaPelna(talia5);
                IfKupkaPelna(talia6);
                IfKupkaPelna(talia7);
                IfKupkaPelna(talia8);
                IfKupkaPelna(talia9);
                IfKupkaPelna(talia10);

                if (iloscRozdan == 5) newkard.IsEnabled = false;

            }
        }



    }


}

