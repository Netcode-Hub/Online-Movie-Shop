using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
