using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rockpaperscisors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml new BitmapImage(new Uri("grafika/kosc1.png", UriKind.Relative))
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private Item Rock { get; set; }
        private Item Paper { get; set; }
        private Item Scissors { get; set; }
        private Item Lizard { get; set; }
        private Item Spock { get; set; }
        private Item Devil { get; set; }
        private Item Love { get; set; }
        private ObservableCollection<Item> Choices { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();

        }

        private void InitializeGame()
        {
            Rock = new Item("Rock", new BitmapImage(new Uri("Images/rock.png", UriKind.Relative)));
            Scissors = new Item("Scissors", new BitmapImage(new Uri("Images/scissors.png", UriKind.Relative)));
            Paper = new Item("Paper", new BitmapImage(new Uri("Images/paper.png", UriKind.Relative)));
            Lizard = new Item("Lizard", new BitmapImage(new Uri("Images/lizard.png", UriKind.Relative)));
            Spock = new Item("Spock", new BitmapImage(new Uri("Images/spock.png", UriKind.Relative)));
            Devil = new Item("Devil", new BitmapImage(new Uri("Images/devil.png", UriKind.Relative)));
            Love = new Item("Love", [Rock, Spock, Devil], [Paper, Lizard, Scissors], new BitmapImage(new Uri("Images/love.png", UriKind.Relative)));
            Rock.AddIsBitingAndLosing([Scissors, Lizard, Devil], [Paper, Spock, Love]);
            Scissors.AddIsBitingAndLosing([Love, Paper, Lizard], [Rock, Spock, Devil]);
            Paper.AddIsBitingAndLosing([Rock, Spock, Love], [Scissors, Lizard, Devil]);
            Lizard.AddIsBitingAndLosing([Love, Spock, Paper], [Scissors, Devil, Rock]);
            Spock.AddIsBitingAndLosing([Scissors, Devil, Rock], [Lizard, Love, Paper]);
            Devil.AddIsBitingAndLosing([Paper, Lizard, Scissors], [Rock, Spock, Love]);


            Choices = new ObservableCollection<Item> { Rock, Paper, Scissors, Spock, Lizard, Devil, Love };
            PlayerChoices.ItemsSource = Choices;
        }

        private void PlayerChoices_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PlayerChoices.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            Item PlayerChoice = PlayerChoices.SelectedItem as Item;
            PlayerImage.Source = PlayerChoice.GetImage();
        }


        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerChoices.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            Item PlayerChoice = PlayerChoices.SelectedItem as Item;
            Item computerChoice = GetComputerChoice();

            ComputerImage.Source = computerChoice.GetImage();

            PlayerResult.Text = PlayerChoice.CompareTo(computerChoice);
            ComputerResult.Text = computerChoice.CompareTo(PlayerChoice);
        }

        private Item GetComputerChoice()
        {
            int index = random.Next(Choices.Count);
            return Choices[index];
        }
    }
}