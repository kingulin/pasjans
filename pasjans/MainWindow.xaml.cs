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
      //  public ObservableCollection<Card> talia { get; set; }
        public int IloscKard { get; set; }
        List<Card> talia = new List<Card>();
        public MainWindow()
        {
            InitializeComponent();
            IloscKard = 104;
        //   talia = new ObservableCollection<Card>();
            DataContext = this;
          talia.Add(new Card { Value = 1 });

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
            foreach (var item in talia)

                item.Value = random.Next(1, 14);
        }

        private void RozdajKarty()
        {

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
