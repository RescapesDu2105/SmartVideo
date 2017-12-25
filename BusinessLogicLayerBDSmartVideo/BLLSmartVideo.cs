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

        public static ClientDTO GetClientById(int idClient)
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

        public static List<LocationDTO> GetLocationsClient(int idClient)
        {
            return dal.GetLocationsClient(idClient);
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

    }
}
