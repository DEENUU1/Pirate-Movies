namespace Pirate_Movies.Models
{
    public class Season
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public ICollection<SeasonShow> SeasonShows { get; set; }
    }
}
