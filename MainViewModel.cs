using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace rockpaperscisors
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> Choices { get; set; }

        private Item _selectedItem;
        private Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public MainViewModel()
        {
            // Initialize your items here
            Choices = new ObservableCollection<Item>
        {
            new Item("Rock", new BitmapImage(new Uri("Images/rock.png", UriKind.Relative))),
            new Item("Paper", new BitmapImage(new Uri("Images/paper.png", UriKind.Relative))),
            new Item("Scissors", new BitmapImage(new Uri("Images/scissors.png", UriKind.Relative))),
            new Item("Lizard", new BitmapImage(new Uri("Images/lizard.png", UriKind.Relative))),
            new Item("Spock", new BitmapImage(new Uri("Images/spock.png", UriKind.Relative))),
            new Item("Devil", new BitmapImage(new Uri("Images/devil.png", UriKind.Relative))),
            new Item("Love", new BitmapImage(new Uri("Images/love.png", UriKind.Relative)))
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
