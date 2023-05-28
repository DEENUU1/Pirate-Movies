namespace Pirate_Movies.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Poster 
        public DateOnly DateRelease { get; set; }
        public string Country { get; set; }
        public Category Category { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
