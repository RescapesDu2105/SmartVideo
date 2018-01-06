using DTOLib;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SmartWCFService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ISmartWCFService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        FilmDTO GetFilmById(int idFilm);

        [OperationContract]
        FilmDTO GetFilmByName(String filmName);

        [OperationContract]
        List<FilmDTO> GetFilms(String table, String critere, int page);

        [OperationContract]
        List<FilmDTO> GetNumberOfFilms();

        [OperationContract]
        FilmDTO GetFilmInfos(FilmDTO Film);

        [OperationContract]
        List<FilmDTO> GetFilmsPage(int page);
        
        [OperationContract]
        List<ActorDTO> GetActors();

        [OperationContract]
        ActorDTO IsActorExists(String actorName);

        [OperationContract]
        List<GenreDTO> GetGenres();

        [OperationContract]
        List<DirectorDTO> GetDirectors();
        
        [OperationContract]
        void UpdateTrailerFilm(int idFilm, String url);

        [OperationContract]
        int CountFilms();

        [OperationContract]
        int CountFilmsRecherche(String table, String critere);


        [OperationContract]
        ClientDTO GetClientById(String idClient);

        [OperationContract]
        HitsDTO GetHitsById(int idHits);

        [OperationContract]
        LocationDTO GetLocationById(int idLocation);

        [OperationContract]
        List<LocationDTO> GetLocationsClient(String idClient);

        [OperationContract]
        void AddLocationClient(String idClient, int idFilm, DateTime date);

        [OperationContract]
        List<ClientDTO> GetClients();

        [OperationContract]
        List<HitsDTO> GetHits();

        [OperationContract]
        List<LocationDTO> GetLocations();

        [OperationContract]
        void AddHits(String IdClient, int IdCritere, DateTime date, String Type);
    }
}
