namespace Pirate_Movies.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateRelease { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Episode> Episodes { get; set;}
    }
}
