namespace Pirate_Movies.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
