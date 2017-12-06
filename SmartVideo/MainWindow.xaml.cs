using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DTOLib;
using BusinessLogicLayer;
using System.Collections.ObjectModel;

namespace SmartVideo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SmartWCFServiceReference.SmartWCFServiceClient clientService;
        ObservableCollection<FilmDTO> listFilmsDTO;
        public int Page { get; set; }
        public int NbPagesMax { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            clientService = new SmartWCFServiceReference.SmartWCFServiceClient();
            listFilmsDTO = new ObservableCollection<FilmDTO>();
            //ListView_ListeFilms.DataContext = new ListFilmsViewModel(listFilmsDTO, clientService);
            ListView_ListeFilms.ItemsSource = listFilmsDTO;

            Page = 1;
            double value = clientService.CountFilms() / 20;
            NbPagesMax = (int) Math.Ceiling(value);
            ChargerDBFilm(Page);
        }

        private void ChargerDBFilm(int ChangeToPage)
        {
            if (ChangeToPage > 0)
            {
                if (ChangeToPage <= NbPagesMax)
                {
                    if (ChangeToPage == NbPagesMax)
                        Button_Suivant.IsEnabled = false;
                    else
                        Button_Suivant.IsEnabled = true;

                    if (ChangeToPage == 1)
                        Button_Precedent.IsEnabled = false;
                    else
                        Button_Precedent.IsEnabled = true;

                    Page = ChangeToPage;
                    listFilmsDTO.Clear();
                    List<FilmDTO> Films = clientService.GetFilmsPage(ChangeToPage - 1).ToList();
                    Films.ForEach(listFilmsDTO.Add);
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            clientService.Close();
        }

        private void LV_LF_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InfosFilmWindow IFW = new InfosFilmWindow(ListView_ListeFilms.SelectedItem as FilmDTO, clientService);
            IFW.ShowDialog();
        }

        private void Button_Precedent_Click(object sender, RoutedEventArgs e)
        {
            ChargerDBFilm(Page - 1);
        }

        private void Button_Suivant_Click(object sender, RoutedEventArgs e)
        {
            ChargerDBFilm(Page + 1);
        }
    }
}
