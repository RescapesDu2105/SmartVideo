using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLib
{
    public class FilmDTO : IEquatable<FilmDTO>
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Original_Title { get; set; }
        public String PosterPath { get; set; }
        public int Runtime { get; set; }
        public String TrailerPath { get; set; }

        public List<GenreDTO> Genres { get; set; }
        public List<ActorDTO> Actors { get; set; }
        public List<DirectorDTO> Directors { get; set; }

        public override string ToString()
        {
            return Id + " | " + Title + " | " + this.Original_Title + " | " + string.Join(", ", Genres) + " | " + string.Join(", ", Actors) + " | " + string.Join(", ", Directors);
        }

        public bool Equals(FilmDTO other)
        {
            return other.Id == Id;
        }
    }
    
    public class ActorDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Character { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }

    public class GenreDTO
    { 
        public int Id { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }

    public class DirectorDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
    
}
