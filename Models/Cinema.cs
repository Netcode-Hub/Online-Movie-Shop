using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        public string Logo { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
