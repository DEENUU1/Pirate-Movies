namespace Pirate_Movies.Models
{
    public class MovieLink
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid LinkId { get; set; }
        public Link Link { get; set; }
    }
}
