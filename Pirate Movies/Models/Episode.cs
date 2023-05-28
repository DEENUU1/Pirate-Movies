namespace Pirate_Movies.Models
{
    public class Episode
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public ICollection<Link> Links { get; set; }
        public Show Show { get; set; }
        public Season Season { get; set; }
        public ICollection<EpisodeLink> EpisodeLinks { get; set; }
    }
}
