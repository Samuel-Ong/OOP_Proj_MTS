using System;
using System.Collections.Generic;
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

namespace Movie_Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //List of movies.
            List<Movie> MovieList = new List<Movie>()
            {
                new Movie("aaaa", 1, "G", new DateTime(2017,1,5), new List<string>() {"Animated", "Comedy" }),
                new Movie("bbbb", 2, "PG13", new DateTime(2017,1,8), new List<string>() {"Horror", "Sexual References" }),
                new Movie("cccc", 2, "NC16", new DateTime(2017,1,15), new List<string>() {"Gore", "Comedy" }),
                new Movie("dddd", 3, "M18", new DateTime(2017,1,25), new List<string>() {"Sexual Content", "Comedy" }),
                new Movie("eeee", 4, "R21", new DateTime(2017,1,28), new List<string>() {"Gore", "Action" })
            };
            //Start of GUI
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Loads the items in the Drop List box. Sets the first item to be "List all movies"
            List<String> OptionsList = new List<string>() { "List all movies", "Add a movie screening session", "List movie screenings", "Delete a movie screening session", "Order movie ticket/s", "Add a movie rating", "View movie ratings and comments" };
            MainMenu.ItemsSource = OptionsList;
            MainMenu.SelectedIndex = 0;
        }

        private void MainMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainMenu.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
            }
        }
    }
}
