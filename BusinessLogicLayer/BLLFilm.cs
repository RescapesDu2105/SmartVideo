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

        public static List<FilmDTO> getFilms()
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
    }
}
