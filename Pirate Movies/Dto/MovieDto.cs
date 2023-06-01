namespace Pirate_Movies.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
    }
}
