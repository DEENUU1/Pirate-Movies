namespace Pirate_Movies.Models
{
    public class EpisodeLink
    {
        public Guid EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public Guid LinkId { get; set; }
        public Link Link { get; set; }

    }
}
