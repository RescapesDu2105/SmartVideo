using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDBFilm
{
    public class DAL
    {
        private DBFilmDataContext instanceDC = null;
        private static DAL singleton;

        public static DAL Singleton(String serverName, String DBName)
        {
            return singleton ?? (singleton = new DAL(serverName, DBName));
        }

        private DAL(String serverName, String DBName)
        {
            if (DBName != null || DBName == "")
                instanceDC = new DBFilmDataContext();
            else
            { 
                String connectionstring = "Data Source = " + serverName + " ; Initial Catalog =" + DBName + "; Integrated Security = True";
                instanceDC = new DBFilmDataContext(connectionstring);
            }
            if (!instanceDC.DatabaseExists())  // Vérifier si la DB existe
                instanceDC.CreateDatabase();   // Si elle n'existe pas, on la crée
        }

    #region Get bunch of films
        public List<FilmDTO> GetNumberOfFilms()
        {
            return GetNumberOfFilms(50);
        }
        public List<FilmDTO> GetNumberOfFilms(int number)
        {

            List<Film> data = instanceDC.Film.OrderBy(d => d.id).Take(number).ToList();

            List<FilmDTO> listBLL = new List<FilmDTO>();

            foreach(var d in data)
            {
                listBLL.Add(ToFilmDTO(d));
            }

            return listBLL;
        }
        public List<FilmDTO> GetFilmsPage(int page)
        {
            List<Film> listFilm = instanceDC.Film.OrderBy(d => d.id).Skip(20 * page).Take(20).ToList();
            List<FilmDTO> listBLL = new List<FilmDTO>();

            foreach (Film film in listFilm)
            {
                listBLL.Add(ToFilmDTO(film));
            }

            return listBLL;
        }
    #endregion Get bunch of films

    #region GetById
        public FilmDTO GetFilmById(int idFilm)
        {
            return ToFilmDTO(instanceDC.Film.Where(d => d.id == idFilm).SingleOrDefault());
        }
        public Genre GetGenreById(int idFilm)
        {
            return instanceDC.Genre.Where(d => d.id == idFilm).SingleOrDefault();
        }
        public Actor GetActorById(int idFilm)
        {
            return instanceDC.Actor.Where(d => d.id == idFilm).SingleOrDefault();
        }
        public Director GetDirectorById(int idFilm)
        {
            return instanceDC.Director.Where(d => d.id == idFilm).SingleOrDefault();
        }
    #endregion GetById

    #region Get
        public List<FilmDTO> GetFilms(String table, String critere, int page)
        {
            List<Film> listFilm = null;
            List<FilmDTO> listFilmDTO = new List<FilmDTO>();

            Console.WriteLine("critere = " + critere);

            switch(table)
            {
                case "Film":
                    listFilm = (from f in instanceDC.Film
                                where f.title.Contains(critere) || f.original_title.Contains(critere)
                                select f).Skip(20 * page).Take(20).OrderBy(d => d.id).ToList();
                    break;

                case "Actor":
                    listFilm = (from a in instanceDC.Actor
                                join fa in instanceDC.FilmActor on a.id equals fa.id_actor
                                join f in instanceDC.Film on fa.id_film equals f.id
                                where a.name.Contains(critere)
                                select f).Skip(20 * page).Take(20).OrderBy(d => d.id).ToList();
                    break;

                case "Genre":
                    listFilm = (from g in instanceDC.Genre
                                join fg in instanceDC.FilmGenre on g.id equals fg.id_genre
                                join f in instanceDC.Film on fg.id_film equals f.id
                                where g.name.Contains(critere)
                                select f).Skip(20 * page).Take(20).OrderBy(d => d.id).ToList();
                    break;

                case "Realisateur":
                    listFilm = (from d in instanceDC.Director
                                join fr in instanceDC.FilmDirector on d.id equals fr.id_realisateur
                                join f in instanceDC.Film on fr.id_film equals f.id
                                where d.name.Contains(critere)
                                select f).Skip(20 * page).Take(20).OrderBy(d => d.id).ToList();
                    break;
                
            }

            foreach (Film film in listFilm)
                listFilmDTO.Add(ToFilmDTO(film));

            return listFilmDTO;
        }
        public FilmDTO GetFilmByName(String filmName)
        {
            return ToFilmDTO(instanceDC.Film.Where(f => f.title.ToUpper().Equals(filmName.ToUpper()) || f.original_title.ToUpper().Equals(filmName.ToUpper())).SingleOrDefault());
        }
        public List<GenreDTO> GetGenres()
        {
            List<GenreDTO> listGenreDTO = new List<GenreDTO>();
            List<Genre> listGenre = instanceDC.Genre.OrderBy(d => d.name).ToList();

            foreach (Genre genre in listGenre)
                listGenreDTO.Add(ToGenreDTO(genre));

            return listGenreDTO;
        }
        public List<ActorDTO> GetActors()
        {
            List<ActorDTO> listActorsDTO = new List<ActorDTO>();
            List<Actor> listActor = instanceDC.Actor.OrderBy(d => d.name).ToList();

            foreach (Actor actor in listActor)
                listActorsDTO.Add(ToActorDTO(actor));

            return listActorsDTO;
        }
        public ActorDTO IsActorExists(String actorName)
        {
            try
            {
                return ToActorDTO((from a in instanceDC.Actor
                                   join fa in instanceDC.FilmActor on a.id equals fa.id_actor
                                   join f in instanceDC.Film on fa.id_film equals f.id
                                   where a.name.ToUpper().Equals(actorName.ToUpper())
                                   select a).SingleOrDefault());
            }
            catch
            {
                return null;
            }
        }
        public List<DirectorDTO> GetDirectors()
        {
            List<DirectorDTO> listDirectorDTO = new List<DirectorDTO>();
            List<Director> listDirector = instanceDC.Director.OrderBy(d => d.name).ToList();

            foreach (Director director in listDirector)
                listDirectorDTO.Add(ToDirectorDTO(director));

            return listDirectorDTO;
        }

        public List<GenreDTO> GetGenresFilm(int idFilm)
        {
            List<Genre> listGenre = null;
            List<GenreDTO> listGenreDTO = new List<GenreDTO>();

            listGenre = (from g in instanceDC.Genre
                         join fg in instanceDC.FilmGenre
                            on g.id equals fg.id_genre
                         join f in instanceDC.Film
                            on fg.id_film equals f.id
                         where f.id == idFilm
                         select g).ToList();

            foreach (Genre genre in listGenre)
                listGenreDTO.Add(ToGenreDTO(genre));

            return listGenreDTO;
        }
        public List<ActorDTO> GetActorsFilm(int idFilm)
        {
            List<Actor> listActor = null;
            List<ActorDTO> listActorDTO = new List<ActorDTO>();

            listActor = (from a in instanceDC.Actor
                         join fa in instanceDC.FilmActor
                            on a.id equals fa.id_actor
                         join f in instanceDC.Film
                            on fa.id_film equals f.id
                         where fa.id_film == idFilm
                         select a).ToList();
            List<ActorDTO> result = new List<ActorDTO>();
            foreach (Actor actor in listActor)
                listActorDTO.Add(ToActorDTO(actor));

            return listActorDTO;
        }
        public List<DirectorDTO> GetDirectorFilm(int idFilm)
        {
            List<Director> listDirector = null;
            List<DirectorDTO> listDirectorDTO = new List<DirectorDTO>();

            listDirector = (from d in instanceDC.Director
                            join fd in instanceDC.FilmDirector
                                on d.id equals fd.id_realisateur
                            join f in instanceDC.Film
                                on fd.id_film equals f.id
                            where f.id == idFilm
                            select d).ToList();
            foreach (Director director in listDirector)
                listDirectorDTO.Add(ToDirectorDTO(director));

            return listDirectorDTO;
        }
        #endregion Get

        public int CountFilms(String table, String critere)
        {
            List<Film> listFilm = null;
            List<FilmDTO> listFilmDTO = new List<FilmDTO>();

            switch (table)
            {
                case "Film":
                    listFilm = (from f in instanceDC.Film
                                where f.title.Contains(critere) || f.original_title.Contains(critere)
                                select f).ToList();
                    break;

                case "Actor":
                    listFilm = (from a in instanceDC.Actor
                                join fa in instanceDC.FilmActor on a.id equals fa.id_actor
                                join f in instanceDC.Film on fa.id_film equals f.id
                                where a.name.Contains(critere)
                                select f).ToList();
                    break;

                case "Genre":
                    listFilm = (from g in instanceDC.Genre
                                join fg in instanceDC.FilmGenre on g.id equals fg.id_genre
                                join f in instanceDC.Film on fg.id_film equals f.id
                                where g.name.Contains(critere)
                                select f).ToList();
                    break;

                case "Realisateur":
                    listFilm = (from d in instanceDC.Director
                                join fr in instanceDC.FilmDirector on d.id equals fr.id_realisateur
                                join f in instanceDC.Film on fr.id_film equals f.id
                                where d.name.Contains(critere)
                                select f).ToList();
                    break;

            }

            foreach (Film film in listFilm)
                listFilmDTO.Add(ToFilmDTO(film));

            return listFilmDTO.Count;
        }

        public int CountFilms()
        {
            return instanceDC.Film.Count();
        }

    #region Action sur un film
        public void UpdateTrailerFilm(int idFilm, String url)
        {
            Film film = instanceDC.Film.Where(d => d.id == idFilm).SingleOrDefault();
            film.trailerpath = url;
            instanceDC.SubmitChanges();
        }
    #endregion Action sur un film

    #region To*DTO
        public FilmDTO ToFilmDTO(Film film)
        {
            FilmDTO filmDTO = new FilmDTO();
            filmDTO.Id = film.id;
            filmDTO.Title = film.title;
            filmDTO.Original_Title = film.original_title;
            filmDTO.Runtime = (int)film.runtime;
            filmDTO.PosterPath = film.posterpath;
            filmDTO.TrailerPath = film.trailerpath;

            return filmDTO;
        }
        public GenreDTO ToGenreDTO(Genre genre)
        {
            GenreDTO genreDTO = new GenreDTO();
            genreDTO.Id = genre.id;
            genreDTO.Name = genre.name;

            return genreDTO;
        }
        public ActorDTO ToActorDTO(Actor a)
        {
            ActorDTO actorDTO = new ActorDTO();
            actorDTO.Id = a.id;
            actorDTO.Name = a.name;
            actorDTO.Character = a.character;

            return actorDTO;
        }
        public DirectorDTO ToDirectorDTO(Director d)
        {
            DirectorDTO directorDTO = new DirectorDTO();
            directorDTO.Id = d.id;
            directorDTO.Name = d.name;

            return directorDTO;
        }
    #endregion To*DTO

    }
}
