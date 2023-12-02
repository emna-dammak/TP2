using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.Models
{
    [Table("movies")]
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GenreId { get; set; }  // Foreign Key
        public Genre Genre { get; set; }  // Navigation property
        public Movie()
        {
        }
    }
}
