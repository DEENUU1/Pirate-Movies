namespace Pirate_Movies.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string Quality { get; set; }
        public int? EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
