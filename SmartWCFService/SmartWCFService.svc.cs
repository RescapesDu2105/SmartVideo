using BusinessLogicLayer;
using BusinessLogicLayerBDSmartVideo;
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

        //DBFilm
        public FilmDTO GetFilmById(int idFilm)
        {
            return BLLFilm.getFilmById(idFilm);
        }
        public ActorDTO GetActorByIdActor(int idActor)
        {
            return BLLFilm.getActorByIdActor(idActor);
        }
        public FilmDTO GetFilmByName(String filmName)
        {
            return BLLFilm.getFilmByName(filmName);
        }
        public List<FilmDTO> GetFilmsPage(int page)
        {
            return BLLFilm.getFilmsPage(page);
        }
        public List<FilmDTO> GetFilms(String table, String critere, int page)
        {
            return BLLFilm.getFilms(table, critere, page);
        }
        public List<FilmDTO> GetNumberOfFilms()
        {
            return BLLFilm.getNumberOfFilms();
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
        public ActorDTO IsActorExists(String actorName)
        {
            return BLLFilm.isActorExists(actorName);
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
        public int CountFilmsRecherche(String table, String critere)
        {
            return BLLFilm.CountFilms(table, critere);
        }

        //BDSmartVideo
        public ClientDTO GetClientById(String idClient)
        {
            return BLLSmartVideo.GetClientById(idClient);
        }
        public HitsDTO GetHitsById(int idHits)
        {
            return BLLSmartVideo.GetHitsById(idHits);
        }
        public LocationDTO GetLocationById(int idLocation)
        {
            return BLLSmartVideo.GetLocationById(idLocation);
        }
        public List<LocationDTO> GetLocationsClient(String idClient)
        {
            return BLLSmartVideo.GetLocationsClient(idClient);
        }
        public void AddLocationClient(String idClient, int idFilm, DateTime date)
        {
            BLLSmartVideo.AddLocationClient(idClient, idFilm, date);
        }
        public List<ClientDTO> GetClients()
        {
            return BLLSmartVideo.GetClients();
        }
        public List<HitsDTO> GetHits()
        {
            return BLLSmartVideo.GetHits();
        }
        public List<LocationDTO> GetLocations()
        {
            return BLLSmartVideo.GetLocations();
        }
        public void AddHits(String IdClient, int IdCritere, DateTime date, String Type)
        {
            BLLSmartVideo.AddHits(IdClient, IdCritere, date, Type);
        }
        public List<HitsDTO> GetHitsFilms()
        {
            return BLLSmartVideo.GetHitsFilms();
        }
        public List<HitsDTO> GetHitsActeurs()
        {
            return BLLSmartVideo.GetHitsActeurs();
        }
        public void AddStatistiques(Dictionary<int, int> Top3Films, Dictionary<int, int> Top3Acteurs)
        {
            BLLSmartVideo.AddStatistiques(Top3Films, Top3Acteurs);
        }
        public List<StatistiquesDTO> GetStatistiquesFilms()
        {
            return BLLSmartVideo.GetStatistiquesFilms();
        }
        public List<StatistiquesDTO> GetStatistiquesActeurs()
        {
            return BLLSmartVideo.GetStatistiquesActeurs();
        }
    }
}
