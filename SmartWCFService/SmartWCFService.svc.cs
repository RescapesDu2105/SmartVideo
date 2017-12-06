using BusinessLogicLayer;
using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartWCFService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class SmartWCFService : ISmartWCFService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public List<FilmDTO> GetFilmsPage(int page)
        {
            return BLLFilm.getFilmsPage(page);
        }
        public List<FilmDTO> GetFilmsDBFilm()
        {
            return BLLFilm.getFilms();
        }
        public void UpdateTrailerFilm(int idFilm, String url)
        {
            BLLFilm.UpdateTrailerFilm(idFilm, url);
        }
        public FilmDTO GetFilmInfos(FilmDTO Film)
        {
            return BLLFilm.getFilmInfos(Film);
        }
        public List<ActorDTO> GetActors()
        {
            return BLLFilm.getActors();
        }
        public List<GenreDTO> GetGenres()
        {
            return BLLFilm.getGenres();
        }
        public List<DirectorDTO> GetDirectors()
        {
            return BLLFilm.getDirectors();
        }
        public int CountFilms()
        {
            return BLLFilm.CountFilms();
        }
    }
}
