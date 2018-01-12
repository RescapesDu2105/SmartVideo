using DataAccessLayerDBFilm;
using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class BLLFilm
    {
        private static DAL dal = DAL.Singleton("(localdb)\\MSSQLLocalDB", "FilmDB");

        public static FilmDTO getFilmById(int idFilm)
        {
            return dal.GetFilmById(idFilm);
        }

        public static FilmDTO getFilmByName(String filmName)
        {
            return dal.GetFilmByName(filmName);
        }
        public static List<FilmDTO> getAllFilms()
        {          
            return dal.GetAllFilms();
        }
        public static List<FilmDTO> getFilms(String table, String critere, int page)
        {
            return dal.GetFilms(table, critere, page);
        }

        public static List<FilmDTO> getNumberOfFilms()
        {
            List<FilmDTO> listFilms = dal.GetNumberOfFilms();

            return listFilms;
        }

        public static List<FilmDTO> getFilmsPage(int page)
        {
            List<FilmDTO> listFilms = dal.GetFilmsPage(page);

            return listFilms;
        }
        
        public static FilmDTO getFilmInfos(FilmDTO Film)
        {
            Film.Actors = dal.GetActorsFilm(Film.Id);
            Film.Directors = dal.GetDirectorFilm(Film.Id);
            Film.Genres = dal.GetGenresFilm(Film.Id);

            return Film;
        }
        public static ActorDTO isActorExists(String actorName)
        {
            return dal.IsActorExists(actorName);
        }
        
        public static List<ActorDTO> getActors()
        {
            return dal.GetActors();
        }

        public static List<GenreDTO> getGenres()
        {
            return dal.GetGenres();
        }

        public static List<DirectorDTO> getDirectors()
        {
            return dal.GetDirectors();
        }

        public static void UpdateTrailerFilm(int idFilm, String url)
        {
            dal.UpdateTrailerFilm(idFilm, url);
        }

        public static int CountFilms()
        {
            return dal.CountFilms();
        }
        public static int CountFilms(String table, String critere)
        {
            return dal.CountFilms(table, critere);
        }
    }
}
