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
        List<FilmDTO> GetFilmsDBFilm();

        [OperationContract]
        FilmDTO GetFilmInfos(FilmDTO Film);

        [OperationContract]
        List<FilmDTO> GetFilmsPage(int page);
        
        [OperationContract]
        List<ActorDTO> GetActors();

        [OperationContract]
        List<GenreDTO> GetGenres();

        [OperationContract]
        List<DirectorDTO> GetDirectors();
        
        [OperationContract]
        void UpdateTrailerFilm(int idFilm, String url);

        [OperationContract]
        int CountFilms();
    }
}
