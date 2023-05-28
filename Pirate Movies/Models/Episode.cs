namespace Pirate_Movies.Models
{
    public class Episode
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        // Links
        public Show ShowId { get; set; }
        public Season Season { get; set; }
    }
}
