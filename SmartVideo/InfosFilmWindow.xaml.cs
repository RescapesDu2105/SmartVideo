using DTOLib;
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
using System.Windows.Shapes;

namespace SmartVideo
{
    /// <summary>
    /// Logique d'interaction pour InfosFilmWindow.xaml
    /// </summary>
    public partial class InfosFilmWindow : Window
    {
        public MainWindow MainWindow { get; set; }
        public ListView ListFilms { get; set; }
        public SmartWCFServiceReference.SmartWCFServiceClient ClientService { get; set; }
        public FilmDTO Film { get; set; }
        
        public InfosFilmWindow(MainWindow MW, ListView LV_LF, SmartWCFServiceReference.SmartWCFServiceClient clientService)
        {
            InitializeComponent();

            MainWindow = MW;
            ListFilms = LV_LF;
            ClientService = clientService;
            Film = LV_LF.SelectedItem as FilmDTO;           
            
            Image_Poster.Source = new BitmapImage(new Uri("http://image.tmdb.org/t/p/w185" + Film.PosterPath, UriKind.RelativeOrAbsolute));
            Titre_Film.Content = Film.Title;
            Original_Title_Film.Content = Film.Original_Title;
            Runtime_Film.Content = Film.Runtime + " minutes";
            if (Film.TrailerPath != null)
                TrailerPath_Film.Text = Film.TrailerPath;

            Film = ClientService.GetFilmInfos(Film);
            LB_Actors.ItemsSource = new ObservableCollection<ActorDTO>(Film.Actors);
            LB_Actors.DisplayMemberPath = "Name";
            LB_Directors.ItemsSource = new ObservableCollection<DirectorDTO>(Film.Directors);
            LB_Directors.DisplayMemberPath = "Name";
            LB_Genres.ItemsSource = new ObservableCollection<GenreDTO>(Film.Genres);
            LB_Genres.DisplayMemberPath = "Name";
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            FilmDTO UpdatedFilm = ListFilms.Items.GetItemAt(ListFilms.SelectedIndex) as FilmDTO;
            if (Film.TrailerPath != TrailerPath_Film.Text)
            {
                ClientService.UpdateTrailerFilm(Film.Id, TrailerPath_Film.Text);
                UpdatedFilm.TrailerPath = TrailerPath_Film.Text;
                ListFilms.Items.Refresh();
            }
        }
    }
}
