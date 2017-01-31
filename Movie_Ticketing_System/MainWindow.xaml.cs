//Student Number : S10171663,  s10171069
//Student name   : Samuel Ong, Seow Chong
//Module Group   : IT05
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
using System.Globalization;

namespace Movie_Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Grid DetailGrid = new Grid() { Height = 527.2, Width = 793.6, ShowGridLines = true, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
        static List<Movie> movieList = new List<Movie>()
        {
            new Movie("The Great Wall", 103, "NC16", new DateTime(2016,12,29), new List<string>() {"Action", "Adventure" }),
            new Movie("Rogue One: A Star Wars Story", 134, "PG13", new DateTime(2016,12,15), new List<string>() {"Action", "Adventure" }),
            new Movie("Office Christmas Party", 106, "M18", new DateTime(2017,1,15), new List<string>() {"Comedy" }),
            new Movie("Power Rangers", 120, "G", new DateTime(2017,1,31), new List<string>() {"Fantasy", "Thriller" })
        };
        static List<CinemaHall> cinemaHallList = new List<CinemaHall>()
        {
            new CinemaHall("Singa North", 1, 30),
            new CinemaHall("Singa North", 2, 10),
            new CinemaHall("Singa West", 1, 50),
            new CinemaHall("Singa East", 1, 5),
            new CinemaHall("Singa Central", 1, 20),
            new CinemaHall("Singa Central", 2, 15)
        };

        static List<Screening> screeningList = new List<Screening>()
        {
            new Screening(new DateTime(2016, 12, 29, 15, 00, 00), "3D", cinemaHallList[2], movieList[0]),
            new Screening(new DateTime(2017, 01, 03, 13, 00, 00), "2D", cinemaHallList[3], movieList[1]),
            new Screening(new DateTime(2017, 01, 31, 19, 00, 00), "3D", cinemaHallList[0], movieList[3]),
            new Screening(new DateTime(2017, 02, 02, 15, 00, 00), "2D", cinemaHallList[1], movieList[3])
        };

        public MainWindow()
        {
            //Start of GUI
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Loads the items in the Drop List box. Sets the first item to be "List all movies"
            List<String> OptionsList = new List<string>() { "List all movies", "Add a movie screening session", "List movie screenings", "Delete a movie screening session", "Order movie ticket/s", "Add a movie rating", "View movie ratings and comments" };
            MainMenu.ItemsSource = OptionsList;
        }

        private void MainMenuTB_GotFocus(object sender, RoutedEventArgs e)
        {
            //The beginning of the Drop list Header.
            MainMenuTB.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Visible;
            MainMenu.Focus();
            MainMenu.IsDropDownOpen = true;
        }

        private void MainMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainMenu.SelectedIndex)
            {
                case 0:
                    ListMovies();
                    break;
                case 1:
                    AddMovieScreening();
                    break;
                case 2:
                    ListMovieScreenings();
                    break;
                case 3:
                    DeleteMovieScreening();
                    break;
                case 4:
                    OrderMovieTickets();
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

        private void ClearSetDetailGrid(Grid TempDetailGrid)
        {
            if (!DetailGrid.Equals(TempDetailGrid))
            {
                RootGrid.Children.Remove(DetailGrid);
                DetailGrid = TempDetailGrid;
                RootGrid.Children.Add(DetailGrid);
            }
        }

        //Create UI for listing of Movies
        private void ListMovies()
        {
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            //Creation of Temp Sub-Grid in main Grid.
            //Options working Area
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            //Creation of a list showing the Movies.
            ListBox movieListBox = new ListBox();
            Grid.SetColumn(movieListBox, 0);
            Grid.SetRow(movieListBox, 0);
            //Creation of the displaying of Data
            TextBlock DataTxtBox = new TextBlock();
            Grid.SetColumn(DataTxtBox, 1);
            Grid.SetRow(DataTxtBox, 0);
            //Setting of the movieListBox
            //Adding of data
            foreach (Movie movie in movieList)
            {
                movieListBox.Items.Add(movie.Title);
            }
            //Adding to the Grid.
            TempDetailGrid.Children.Add(movieListBox);
            TempDetailGrid.Children.Add(DataTxtBox);
            ClearSetDetailGrid(TempDetailGrid);
            movieListBox.SelectionChanged += (sender, EventArgs) => { Opt1_movieListBox_SelectionChanged(sender, EventArgs, movieListBox, DataTxtBox); };
        }

        //Updates the detailbox whenever the choice changes.
        private void Opt1_movieListBox_SelectionChanged(object sender, SelectionChangedEventArgs e, ListBox movieListBox, TextBlock DataTxtBox)
        {
            //Sets all the genres from the movie into one variable.
            int movieindex = movieListBox.SelectedIndex;
            string moviegenre = movieList[movieindex].GenreList[0];
            for (int i = 1; i < movieList[movieindex].GenreList.Count; i++)
            {
                moviegenre += ", " + movieList[movieindex].GenreList[i];
            }
            //Displays the details in the DetailBox
            DataTxtBox.Text = string.Format("{0}{1}\n{2}{3}\n{4}{5}\n{6}{7}\n{8}{9}", "Title : ", movieList[movieindex].Title, "Duration : ", movieList[movieindex].Duration, "Genre : ", moviegenre, "Classification : ", movieList[movieindex].Classification, "Opening Date : ", movieList[movieindex].OpeningDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture));
        }

        private void AddMovieScreening()
        {
            //Creation of Temp Sub-Grid in Main Grid
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            TempDetailGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(400) });
            //Layout for buttons
            TempDetailGrid.RowDefinitions.Add(new RowDefinition());
            TempDetailGrid.RowDefinitions.Add(new RowDefinition());
            //Creation of a list to show the Cinemas
            ListBox cinemaListBox = new ListBox();
            Grid.SetColumn(cinemaListBox, 0);
            Grid.SetRow(cinemaListBox, 0);
            foreach (CinemaHall cinemahall in cinemaHallList)
            {
                cinemaListBox.Items.Add(cinemahall.Name);
            }
            //Display of data
            TextBlock DataTxtBox = new TextBlock();
            Grid.SetColumn(DataTxtBox, 1);
            Grid.SetRow(DataTxtBox, 0);
            //Buttons
            Button Next = new Button() { Content = "Next" };
            Grid.SetColumn(Next, 0);
            Grid.SetRow(Next, 1);
            Next.Click += (sender, EventArgs) => { Opt2_Next_Click(sender, EventArgs, cinemaListBox); };
            //Adding everything into the temp grid
            TempDetailGrid.Children.Add(cinemaListBox);
            TempDetailGrid.Children.Add(Next);
            TempDetailGrid.Children.Add(DataTxtBox);
            ClearSetDetailGrid(TempDetailGrid);
            cinemaListBox.SelectionChanged += (sender, EventArgs) => { Opt2_cinemaListBox_SelectionChanged(sender, EventArgs, cinemaListBox, DataTxtBox); };
        }

        //Updates the detailbox whenever the choice changes.
        private void Opt2_cinemaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e, ListBox cinemaListBox, TextBlock DataTxtBox)
        {
            int cinemaindex = cinemaListBox.SelectedIndex;
            //Displays the details in the CinemaDetailBox
            DataTxtBox.Text = string.Format("{0}{1}\n{2}{3}", "Hall Number : ", cinemaHallList[cinemaindex].HallNo, "Capacity : ", cinemaHallList[cinemaindex].Capacity);
        }

        private void Opt2_Next_Click(object sender, RoutedEventArgs e, ListBox cinemaListBox)
        {
            if (cinemaListBox.SelectedItem == null)
            {
                MessageBox.Show("Please pick an option");
                return;
            }
            int cinemaindex = cinemaListBox.SelectedIndex;
            //Creation of Temp Sub-Grid in Main Grid
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            TempDetailGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(400) });
            //Layout for buttons
            TempDetailGrid.RowDefinitions.Add(new RowDefinition());
            TempDetailGrid.RowDefinitions.Add(new RowDefinition());
            //Creation of a list to show the Cinemas
            ListBox movieListBox = new ListBox();
            Grid.SetColumn(movieListBox, 0);
            Grid.SetRow(movieListBox, 0);
            foreach (Movie movie in movieList)
            {
                movieListBox.Items.Add(movie.Title);
            }
            //Display of Data
            TextBlock DataTxtBox = new TextBlock();
            Grid.SetColumn(DataTxtBox, 1);
            Grid.SetRow(DataTxtBox, 0);
            //Buttons
            //Finish button
            Button Finish = new Button() { Content = "Finished" };
            Grid.SetColumn(Finish, 0);
            Grid.SetRow(Finish, 1);
            Finish.Click += (sender1, EventArgs) => { Opt2_Finish_Click(sender, EventArgs, movieListBox, cinemaindex); };
            //Back button
            Button Back = new Button() { Content = "Back" };
            Grid.SetColumn(Back, 0);
            Grid.SetRow(Back, 2);
            Back.Click += Opt2_Back_Click;
            //Adding everything into the Temp Grid
            TempDetailGrid.Children.Add(movieListBox);
            TempDetailGrid.Children.Add(Finish);
            TempDetailGrid.Children.Add(Back);
            TempDetailGrid.Children.Add(DataTxtBox);
            ClearSetDetailGrid(TempDetailGrid);
            movieListBox.SelectionChanged += (sender1, EventArgs) => { Opt1_movieListBox_SelectionChanged(sender1, EventArgs, movieListBox, DataTxtBox); };
        }

        private void Opt2_Finish_Click(object sender, RoutedEventArgs e, ListBox movieListBox, int cinemaindex)
        {
            if (movieListBox.SelectedItem == null)
            {
                MessageBox.Show("Please pick an option");
                return;
            }
            int movieindex = movieListBox.SelectedIndex;
            //A new window to get input from the user
            //Window Layout
            Window msgBox = new Window() { Width = 200, Height = 300, ResizeMode = ResizeMode.NoResize };
            Grid msgBoxGrid = new Grid();
            msgBox.Content = msgBoxGrid;
            msgBoxGrid.RowDefinitions.Add(new RowDefinition());
            msgBoxGrid.RowDefinitions.Add(new RowDefinition());
            msgBoxGrid.RowDefinitions.Add(new RowDefinition());
            msgBoxGrid.RowDefinitions.Add(new RowDefinition());
            ComboBox screeningType = new ComboBox();
            //Loading all the important things
            screeningType.ItemsSource = new List<String>() { "3D", "2D" };
            Grid.SetRow(screeningType, 0);
            TextBlock screeningDateTime = new TextBlock() { Text = "Screening date and time [e.g.DD/MM/YYYY HH:MM]", TextWrapping = TextWrapping.Wrap };
            Grid.SetRow(screeningDateTime, 1);
            TextBox inputbox = new TextBox() { Text = "Please type here" };
            Grid.SetRow(inputbox, 2);
            Button button = new Button();
            button.Content = "Press this button to proceed";
            Grid.SetRow(button, 3);
            button.Click += (sender1, EventArgs) => { Opt2_Finalised_Click(sender, EventArgs, msgBox, cinemaindex, movieindex, Convert.ToString(screeningType.SelectedItem), inputbox.Text); };
            msgBoxGrid.Children.Add(screeningType);
            msgBoxGrid.Children.Add(screeningDateTime);
            msgBoxGrid.Children.Add(inputbox);
            msgBoxGrid.Children.Add(button);
            msgBox.ShowDialog();
        }

        private void Opt2_Back_Click(object sender, RoutedEventArgs e)
        {
            AddMovieScreening();
        }

        private void Opt2_Finalised_Click(object sender, RoutedEventArgs e, Window screen, int cinemaindex, int movieindex, string screeningtype, string datetime)
        {
            DateTime dateTime;
            if (!DateTime.TryParseExact(datetime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                MessageBox.Show("Invalid input");
                return;
            }
            screeningList.Add(new Screening(dateTime, screeningtype, cinemaHallList[cinemaindex], movieList[movieindex]));
            MessageBox.Show("Movie screening successfully created.", "Completed!", MessageBoxButton.OK);
            screen.Close();
            AddMovieScreening();
        }

        private void ListMovieScreenings()
        {
            //Copied from Listing of Movies
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            //Creation of Temp Sub-Grid in main Grid.
            //Options working Area
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength() });
            //Creation of a list showing the Movies.
            ListBox movieListBox = new ListBox();
            Grid.SetColumn(movieListBox, 0);
            Grid.SetRow(movieListBox, 0);
            //Creation of the displaying of Data
            TextBlock DataTxtBox = new TextBlock();
            Grid.SetColumn(DataTxtBox, 1);
            Grid.SetRow(DataTxtBox, 0);
            //Setting of the movieListBox
            //Adding of data
            foreach (Movie movie in movieList)
            {
                movieListBox.Items.Add(movie.Title);
            }
            //Adding to the Grid.
            TempDetailGrid.Children.Add(movieListBox);
            TempDetailGrid.Children.Add(DataTxtBox);
            ClearSetDetailGrid(TempDetailGrid);
            movieListBox.SelectionChanged += (sender, EventArgs) => { Opt3_movieListBox_SelectionChanged(sender, EventArgs, movieListBox, DataTxtBox); };
        }

        //Updates the detailbox whenever the choice changes.
        private void Opt3_movieListBox_SelectionChanged(object sender, SelectionChangedEventArgs e, ListBox movieListBox, TextBlock DataTxtBox)
        {
            bool found = false;
            DataTxtBox.Text = "";
            foreach (Screening screening in screeningList)
            {
                if (Convert.ToString(movieListBox.SelectedItem) == screening.Movie.Title)
                {
                    DataTxtBox.Text += string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}","Location : ", screening.CinemaHall.Name, "\nMovie : ", screening.Movie.Title, "\nType : ", screening.ScreeningType, "\nDate/Time : ", Convert.ToString(screening.ScreeningDateTime), "\nSeats Remaining : ", Convert.ToString(screening.SeatsRemaining) + "\n\n");
                    found = true;
                }
            }
            if (found == false) { DataTxtBox.Text = "No screening available"; }
        }

        private void DeleteMovieScreening()
        {
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            //Grid Layout
            TempDetailGrid.RowDefinitions.Add(new RowDefinition());
            TempDetailGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
            //Creation of Temp Sub-Grid in main Grid.
            //Options working Area
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            ListBox DataTxtBox = new ListBox() { };
            Grid.SetColumn(DataTxtBox, 0);
            Grid.SetRow(DataTxtBox, 0);
            foreach (Screening screening in screeningList)
            {
                DataTxtBox.Items.Add(string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", "No : ", screening.ScreeningNo, "\nLocation : ", screening.CinemaHall.Name, "\nHall No : ", Convert.ToString(screening.CinemaHall.HallNo), "\nTitle : ", screening.Movie.Title , "Date/Time : ", Convert.ToString(screening.ScreeningDateTime)));
            }
            //Button
            Button Delete = new Button() { Content = "Delete Screening" };
            Grid.SetColumn(Delete, 0);
            Grid.SetRow(Delete, 1);
            Delete.Click += (sender, EventArgs) => { Opt4_Delete_Click(sender, EventArgs, DataTxtBox, screeningList); };
            //Adding to the Grid.
            TempDetailGrid.Children.Add(DataTxtBox);
            TempDetailGrid.Children.Add(Delete);
            ClearSetDetailGrid(TempDetailGrid);
        }

        private void Opt4_Delete_Click(object sender, RoutedEventArgs e, ListBox DataTxtBox, List<Screening> screeninglist)
        {
            if (DataTxtBox.SelectedItem == null)
            {
                MessageBox.Show("Please pick an option");
                return;
            }
            screeningList.RemoveAt(DataTxtBox.SelectedIndex);
            DataTxtBox.Items.RemoveAt(DataTxtBox.SelectedIndex);
            DataTxtBox.Items.Refresh();
            MessageBox.Show("Screening Deleted");
            DeleteMovieScreening();
        }

        private void OrderMovieTickets()
        {
            //Copied from Listing of Movies
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            //Grid Layout
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });
            TempDetailGrid.ColumnDefinitions.Add(new ColumnDefinition());
            TempDetailGrid.RowDefinitions.Add(new RowDefinition());
            TempDetailGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            //Creation of Temp Sub-Grid in main Grid.
            //Options working Area
            ListBox movieListBox = new ListBox();
            Grid.SetColumn(movieListBox, 0);
            Grid.SetRow(movieListBox, 0);
            //Creation of the displaying of Data
            TextBlock DataTxtBox = new TextBlock();
            Grid.SetColumn(DataTxtBox, 1);
            Grid.SetRow(DataTxtBox, 0);
            Grid.SetRowSpan(DataTxtBox, 1);
            //Adding of data
            foreach (Movie movie in movieList)
            {
                movieListBox.Items.Add(movie.Title);
            }
            //Button
            Button Next = new Button() { Content = "Next" };
            Grid.SetColumn(Next, 0);
            Grid.SetRow(Next, 1);
            TempDetailGrid.Children.Add(movieListBox);
            TempDetailGrid.Children.Add(Next);
            Next.Click += (sender, EventArgs) => { Opt5_Next_Click1(sender, EventArgs, movieListBox); };
            movieListBox.SelectionChanged += (sender1, EventArgs) => { Opt1_movieListBox_SelectionChanged(sender1, EventArgs, movieListBox, DataTxtBox); };
            ClearSetDetailGrid(TempDetailGrid);
        }

        private void Opt5_Next_Click1(object sender, RoutedEventArgs e, ListBox movieListBox)
        {
            if (movieListBox.SelectedItem == null)
            {
                MessageBox.Show("Please pick an option");
                return;
            }
            int movieindex = movieListBox.SelectedIndex;
            //Copied from Listing of Movies
            Grid TempDetailGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Colors.White) };
            //Creation of Temp Sub-Grid in main Grid.
            //Options working Area
            Grid.SetColumn(TempDetailGrid, 0);
            Grid.SetRow(TempDetailGrid, 2);
            TempDetailGrid.RowDefinitions.Add(new RowDefinition() { });
            TempDetailGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
            //Creation of the displaying of Screenings
            ListBox DataTxtBox = new ListBox();
            Grid.SetColumn(DataTxtBox, 0);
            Grid.SetRow(DataTxtBox, 0);
            //Setting of the movieListBox
            //Adding of data
            foreach (Screening screening in screeningList)
            {
                if (screening.Movie == movieList[movieListBox.SelectedIndex])
                {
                    DataTxtBox.Items.Add(string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", "No : ", screening.ScreeningNo, "\nLocation : ", screening.CinemaHall.Name, "\nHall No : ", Convert.ToString(screening.CinemaHall.HallNo), "\nDate/Time : ", Convert.ToString(screening.ScreeningDateTime), "\nSeats Remaining : ", Convert.ToString(screening.SeatsRemaining)));
                }
            }
            //Button
            Button Next = new Button() { Content = "Next" };
            Grid.SetColumn(Next, 0);
            Grid.SetRow(Next, 1);
            Next.Click += (sender1, EventArgs) => { Opt5_Next_Click2(sender, EventArgs, DataTxtBox, movieindex); };
            //Adding to the Grid.
            TempDetailGrid.Children.Add(Next);
            TempDetailGrid.Children.Add(movieListBox);
            TempDetailGrid.Children.Add(DataTxtBox);
            ClearSetDetailGrid(TempDetailGrid);
        }

        private void Opt5_Next_Click2(object sender, RoutedEventArgs e, ListBox DataTxtBox, int movieindex)
        {

        }
    }
}