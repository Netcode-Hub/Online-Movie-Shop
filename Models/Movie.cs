using MovieShop.Models.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema {get; set;}

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer {get; set;}

    }
}
