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
        public ClientDTO GetClientById(String idClient)
        {
            return ToClientDTO(instanceDC.AspNetUsers.Where(d => d.Id == idClient).SingleOrDefault());
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
        public List<LocationDTO> GetLocationsClient(String idClient)
        {
            List<Location> listLocations = instanceDC.Location.OrderBy(d => d.Id).ToList();
            List<LocationDTO> listLocationDTO = new List<LocationDTO>();

            foreach (Location location in listLocations)
            {
                listLocationDTO.Add(ToLocationDTO(location));
            }

            return listLocationDTO;
        }
        public void AddLocationClient(String idClient, int idFilm, DateTime date)
        {
            Location location = new Location
            {
                IdClient = idClient,
                IdFilm = idFilm,
                DateFin = date
            };

            instanceDC.GetTable<Location>().InsertOnSubmit(location);
            instanceDC.SubmitChanges();
        }
        public void AddHits(String IdClient, int IdCritere, DateTime date, String Type)
        {
            Hits hits = new Hits
            {
                IdClient = IdClient,
                IdType = IdCritere,
                Date = date,
                Type = Type
            };

            instanceDC.GetTable<Hits>().InsertOnSubmit(hits);
            instanceDC.SubmitChanges();
        }
        public void AddStatistiques(Dictionary<int, int> Top3Films, Dictionary<int, int> Top3Acteurs)
        {
            for(int i = 0; Top3Films.Count > 0 && i < 3; i++)
            {
                Statistiques statistiques = new Statistiques()
                {
                    //Id = instanceDC.GetTable<Statistiques>().Count() + 1,
                    Date = DateTime.Now,
                    Type = "Film",
                    IdType = Top3Films.ElementAt(i).Key,
                    NombreHits = Top3Films.ElementAt(i).Value
                };
                instanceDC.GetTable<Statistiques>().InsertOnSubmit(statistiques);
            }

            for (int i = 0; Top3Acteurs.Count > 0 && i < 3; i++)
            {
                Statistiques statistiques = new Statistiques()
                {
                    //Id = instanceDC.GetTable<Statistiques>().Count() + 1,
                    Date = DateTime.Now,
                    Type = "Acteur",
                    IdType = Top3Acteurs.ElementAt(i).Key,
                    NombreHits = Top3Acteurs.ElementAt(i).Value
                };
                instanceDC.GetTable<Statistiques>().InsertOnSubmit(statistiques);
            }

            instanceDC.SubmitChanges();
        }
        public List<HitsDTO> GetHitsFilms()
        {
            /*DateTime date = DateTime.Now.AddDays(-1.0);
            List<int> listeHits = instanceDC.Hits
                                        .Where(h => h.Date.Year == date.Year && h.Date.Month == date.Month && h.Date.Day == date.Day && h.Type == "Film")
                                        .GroupBy(h => h.IdType) //&& h.Date.Year == date.Year && h.Date.Month == date.Month && h.Date.Day == date.Day && h.Type == "Film")
                                        .Select(grp => grp.Key)
                                        .Take(3)
                                        .ToList();

            return listeHits;*/

            List<Hits> Hits = instanceDC.Hits.Where(h => h.Type.Equals("Film")).ToList();
            List<HitsDTO> HitsDTO = new List<HitsDTO>();

            foreach (Hits hits in Hits)
            {
                HitsDTO.Add(ToHitsDTO(hits));
            }

            return HitsDTO;
        }
        public List<HitsDTO> GetHitsActeurs()
        {
            List<Hits> Hits = instanceDC.Hits.Where(h => h.Type.Equals("Acteur")).ToList();
            List<HitsDTO> HitsDTO = new List<HitsDTO>();

            foreach(Hits hits in Hits)
            {
                HitsDTO.Add(ToHitsDTO(hits));
            }

            return HitsDTO;
        }
        #region Get All
        public List<ClientDTO> GetClients()
        {
            List<AspNetUsers> listClients = instanceDC.AspNetUsers.OrderBy(d => d.Id).ToList();
            List<ClientDTO> listClientDTO = new List<ClientDTO>();

            foreach (AspNetUsers client in listClients)
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
        public List<StatistiquesDTO> GetStatistiquesFilms()
        {
            DateTime Date = DateTime.Now.AddDays(-1.0);
            List<Statistiques> listStats = instanceDC.Statistiques.Where(s => s.Date.Year == Date.Year && s.Date.Month == Date.Month && s.Date.Day == Date.Day && s.Type.Equals("Film")).OrderBy(s => s.NombreHits).ToList();
            List<StatistiquesDTO> listStatsDTO = new List<StatistiquesDTO>();

            foreach (Statistiques stats in listStats)
            {
                listStatsDTO.Add(ToStatistiquesDTO(stats));
            }

            return listStatsDTO;
        }
        public List<StatistiquesDTO> GetStatistiquesActeurs()
        {
            DateTime Date = DateTime.Now.AddDays(-1.0);
            List<Statistiques> listStats = instanceDC.Statistiques.Where(s => s.Date.Year == Date.Year && s.Date.Month == Date.Month && s.Date.Day == Date.Day && s.Type.Equals("Acteur")).OrderBy(s => s.NombreHits).ToList();
            List<StatistiquesDTO> listStatsDTO = new List<StatistiquesDTO>();

            foreach (Statistiques stats in listStats)
            {
                listStatsDTO.Add(ToStatistiquesDTO(stats));
            }

            return listStatsDTO;
        }
        #endregion

        #region To*DTO
        public ClientDTO ToClientDTO(AspNetUsers client)
        {
            ClientDTO clientDTO = new ClientDTO();
            clientDTO.Id = client.Id;
            clientDTO.Nom = client.FirstName;
            clientDTO.Prenom = client.LastName;
            clientDTO.Login = client.UserName;
            clientDTO.Mail = client.Email;

            return clientDTO;
        }
        public HitsDTO ToHitsDTO(Hits hits)
        {
            HitsDTO hitsDTO = new HitsDTO();
            hitsDTO.Id = hits.Id;
            hitsDTO.IdClient = hits.IdClient;
            hitsDTO.Date = hits.Date;
            hitsDTO.Type = hits.Type;
            hitsDTO.IdType = hits.IdType;

            return hitsDTO;
        }
        public LocationDTO ToLocationDTO(Location location)
        {
            LocationDTO locationDTO = new LocationDTO();
            locationDTO.Id = location.Id;
            locationDTO.IdFilm = location.IdFilm;
            locationDTO.IdClient = location.IdClient;
            locationDTO.DateFin = location.DateFin;

            return locationDTO;
        }
        public StatistiquesDTO ToStatistiquesDTO(Statistiques stats)
        {
            StatistiquesDTO statsDTO = new StatistiquesDTO();
            statsDTO.Id = stats.Id;
            statsDTO.Type = stats.Type;
            statsDTO.IdType = stats.IdType;
            statsDTO.Date = stats.Date;
            statsDTO.NombreHits = stats.NombreHits;

            return statsDTO;
        }
        #endregion To*DTO
    }
}
