namespace Pirate_Movies.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
