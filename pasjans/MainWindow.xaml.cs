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
           public ObservableCollection<Card> taliaPod { get; set; }
       
        public int IloscKard { get; set; }
   //     List<Card> talia = new List<Card>();
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
            taliaPod = new ObservableCollection<Card>();
            IloscKard = 104;
            // talia.Add(new Card { Value = 1 });

        }
        

        private void Button_Card_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var card = button.DataContext as Card;
            card.IsSelected = !card.IsSelected;
        }
   
        private void TasujKarty()
        {
            var random = new Random();
            //foreach (var item in talia)
          //      item.Value = random.Next(1, 14);
        for(int i = 1;  i <= 14; i++)
            {
                for(int j = 1; j <= 1; j++) {
                    taliaPod.Add(new Card { Value = i });
                }
            }
        }
        private void RozdajKarty(object sender, RoutedEventArgs e)
        {
            RozdajKartyOdwrot(6);

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
                talia.Add(new Card());
                talia2.Add(new Card());
                talia3.Add(new Card());
                talia4.Add(new Card());

            }
            for (int i = 0; i < x-1; i++)
            {
                talia5.Add(new Card());
                talia6.Add(new Card());
                talia7.Add(new Card());
                talia8.Add(new Card());
                talia9.Add(new Card());
                talia10.Add(new Card());

            }
            TasujKarty();
        }

        private void PokażPlansze() { 
        
        }

        private void IfWin()
        {

        }

        private void Ruch()
        {

        }
    }
}
