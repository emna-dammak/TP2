namespace TP2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }

    }
}
