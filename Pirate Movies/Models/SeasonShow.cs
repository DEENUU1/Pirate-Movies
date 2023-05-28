namespace Pirate_Movies.Models
{
    public class SeasonShow
    {
        public Guid ShowId { get; set; }
        public Show Show { get; set; }

        public Guid SeasonId { get; set; }
        public Season Season { get; set; }

    }
}
