using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLib;

namespace DataAccessLayerBDSmartVideo
{
    public class DAL
    {
        private BDSmartVideoDataContext instanceDC = null;
        private static DAL singleton;

        public static DAL Singleton(String serverName, String DBName)
        {
            return singleton ?? (singleton = new DAL(serverName, DBName));
        }

        private DAL(String serverName, String DBName)
        {
            if (DBName != null || DBName == "")
                instanceDC = new BDSmartVideoDataContext();
            else
            {
                String connectionstring = "Data Source = " + serverName + " ; Initial Catalog =" + DBName + "; Integrated Security = True";
                instanceDC = new BDSmartVideoDataContext(connectionstring);
            }
            if (!instanceDC.DatabaseExists())  // Vérifier si la DB existe
                instanceDC.CreateDatabase();   // Si elle n'existe pas, on la crée
        }

        #region Get by id
        public ClientDTO GetClientById(int idClient)
        {
            return ToClientDTO(instanceDC.Client.Where(d => d.Id == idClient).SingleOrDefault());
        }
        public HitsDTO GetHitsById(int idHits)
        {
            return ToHitsDTO(instanceDC.Hits.Where(d => d.Id == idHits).SingleOrDefault());
        }
        public LocationDTO GetLocationById(int idLocation)
        {
            return ToLocationDTO(instanceDC.Location.Where(d => d.Id == idLocation).SingleOrDefault());
        }
        #endregion Get by id
        public List<LocationDTO> GetLocationsClient(int idClient)
        {
            List<Location> listLocations = instanceDC.Location.OrderBy(d => d.Id).ToList();
            List<LocationDTO> listLocationDTO = new List<LocationDTO>();

            foreach (Location location in listLocations)
            {
                listLocationDTO.Add(ToLocationDTO(location));
            }

            return listLocationDTO;
        }
        #region Get All
        public List<ClientDTO> GetClients()
        {
            List<Client> listClients = instanceDC.Client.OrderBy(d => d.Id).ToList();
            List<ClientDTO> listClientDTO = new List<ClientDTO>();

            foreach (Client client in listClients)
            {
                listClientDTO.Add(ToClientDTO(client));
            }

            return listClientDTO;
        }
        public List<HitsDTO> GetHits()
        {
            List<Hits> listHits = instanceDC.Hits.OrderBy(d => d.Id).ToList();
            List<HitsDTO> listHitsDTO = new List<HitsDTO>();

            foreach (Hits hits in listHits)
            {
                listHitsDTO.Add(ToHitsDTO(hits));
            }

            return listHitsDTO;
        }
        public List<LocationDTO> GetLocations()
        {
            List<Location> listLocations = instanceDC.Location.OrderBy(d => d.Id).ToList();
            List<LocationDTO> listLocationDTO = new List<LocationDTO>();

            foreach (Location location in listLocations)
            {
                listLocationDTO.Add(ToLocationDTO(location));
            }

            return listLocationDTO;
        }
        #endregion

        #region To*DTO
        public ClientDTO ToClientDTO(Client client)
        {
            ClientDTO clientDTO = new ClientDTO();
            clientDTO.Id = client.Id;
            clientDTO.Nom = client.Nom;
            clientDTO.Prenom = client.Prenom;
            clientDTO.Login = client.Login;
            clientDTO.Password = client.Password;
            clientDTO.Adresse = client.Adresse;
            clientDTO.Mail = client.Mail;

            return clientDTO;
        }
        public HitsDTO ToHitsDTO(Hits hits)
        {
            HitsDTO hitsDTO = new HitsDTO();
            hitsDTO.Id = hits.Id;
            hitsDTO.IdClient = hits.IdClient;
            hitsDTO.Date = hits.Date;
            hitsDTO.Critere = hits.Critere;

            return hitsDTO;
        }
        public LocationDTO ToLocationDTO(Location location)
        {
            LocationDTO locationDTO = new LocationDTO();
            locationDTO.Id = location.Id;
            locationDTO.IdFilm = location.IdFilm;
            locationDTO.IdClient = location.IdClient;
            locationDTO.DateDebut = location.DateDebut;
            locationDTO.DateFin = location.DateFin;

            return locationDTO;
        }
        #endregion To*DTO
    }
}
