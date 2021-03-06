﻿using System;
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

    public class ClientDTO : IEquatable<ClientDTO>
    {
        public String Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Login { get; set; }
        public String Mail { get; set; }

        public override string ToString()
        {
            return Nom + " | " + Prenom + " | " + Mail;
        }

        public bool Equals(ClientDTO other)
        {
            return other.Id == Id;
        }
    }

    public class HitsDTO : IEquatable<HitsDTO>
    {
        public int Id { get; set; }
        public String IdClient { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }
        public int IdType { get; set; }

        public override string ToString()
        {
            return IdClient + " | " +  Date + " | " + Type;
        }

        public bool Equals(HitsDTO other)
        {
            return other.Id == Id;
        }
    }

    public class LocationDTO : IEquatable<LocationDTO>
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public String IdClient { get; set; }
        public DateTime DateFin { get; set; }

        public override string ToString()
        {
            return IdClient + " | " + IdFilm  + " | " + DateFin;
        }

        public bool Equals(LocationDTO other)
        {
            return other.Id == Id;
        }
    }

    public class StatistiquesDTO : IEquatable<StatistiquesDTO>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }
        public int IdType { get; set; }
        public int NombreHits { get; set; }

        public override string ToString()
        {
            return Date + " | " + Type + " | " + NombreHits;
        }

        public bool Equals(StatistiquesDTO other)
        {
            return other.Id == Id;
        }
    }
}
