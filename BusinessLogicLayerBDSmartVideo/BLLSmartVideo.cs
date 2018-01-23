using DataAccessLayerBDSmartVideo;
using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerBDSmartVideo
{
    public class BLLSmartVideo
    {
        private static DAL dal = DAL.Singleton("(localdb)\\MSSQLLocalDB", "DBSmartVideo");

        public static ClientDTO GetClientById(String idClient)
        {
            return dal.GetClientById(idClient);
        }
        public static HitsDTO GetHitsById(int idHits)
        {
            return dal.GetHitsById(idHits);
        }
        public static LocationDTO GetLocationById(int idLocation)
        {
            return dal.GetLocationById(idLocation);
        }

        public static List<LocationDTO> GetLocationsClient(String idClient)
        {
            return dal.GetLocationsClient(idClient);
        }
        public static void AddLocationClient(String idClient, int idFilm, DateTime date)
        {
            dal.AddLocationClient(idClient, idFilm, date);
        }
        public static void AddStatistiques(Dictionary<int, int> Top3Films, Dictionary<int, int> Top3Acteurs)
        {
            dal.AddStatistiques(Top3Films, Top3Acteurs);
        }

        public static List<ClientDTO> GetClients()
        {
            return dal.GetClients();
        }
        public static List<HitsDTO> GetHits()
        {
            return dal.GetHits();
        }
        public static List<LocationDTO> GetLocations()
        {
            return dal.GetLocations();
        }
        public static void AddHits(String IdClient, int IdCritere, DateTime date, String Type)
        {
            dal.AddHits(IdClient, IdCritere, date, Type);
        }
        public static List<HitsDTO> GetHitsFilms()
        {
            return dal.GetHitsFilms();
        }
        public static List<HitsDTO> GetHitsActeurs()
        {
            return dal.GetHitsActeurs();
        }
        public static List<StatistiquesDTO> GetStatistiquesFilms()
        {
            return dal.GetStatistiquesFilms();
        }
        public static List<StatistiquesDTO> GetStatistiquesActeurs()
        {
            return dal.GetStatistiquesActeurs();
        }
    }
}
