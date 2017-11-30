using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLib
{
    public class FilmDTO : IEquatable<FilmDTO>
    {
        private int _id;
        private String _title;
        private String _original_title;
        private String _poster_path;
        private int _runtime;
        private String _trailer_path;

        private List<GenreDTO> _genres;
        private List<ActorDTO> _actors;
        private List<DirectorDTO> _directors;


        public int Id { get; set; }
        public String Title { get; set; }
        public String Original_Title { get; set; }
        public String Poster_Path { get; set; }
        public int Runtime { get; set; }
        public String Trailer_Path { get; set; }       
        
        public List<GenreDTO> Genres { get; set; }
        public List<ActorDTO> Actors { get; set; }
        public List<DirectorDTO> Directors { get; set; }

        public override string ToString()
        {
            return Id + " | " + Title + " | " + this.Original_Title + " | " + Runtime + " | " + Poster_Path + " | " + Trailer_Path + " | " + string.Join(", ", Genres) + " | " + string.Join(", ", Actors) + " | " + string.Join(", ", Directors);
        }

        public bool Equals(FilmDTO other)
        {
            return other.Id == Id;
        }
    }
    
    public class ActorDTO
    {
        private int _id;
        private String _name;
        private String _character;

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
        private int _id;
        private String _name;        

        public int Id { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }

    public class DirectorDTO
    {
        private int _id;
        private String _name;

        public int Id { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
    
}
