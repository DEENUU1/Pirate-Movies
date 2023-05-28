namespace Pirate_Movies.Models
{
    public class Show
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // poster
        public DateOnly DateRelease { get; set; }
        public string Country { get; set; }
        public Category Category { get; set; }
        public ICollection<Season> Seasons { get; set; }
    }
}
