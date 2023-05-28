namespace Pirate_Movies.Models
{
    public class Link
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public string Quality { get; set; }
    }
}
