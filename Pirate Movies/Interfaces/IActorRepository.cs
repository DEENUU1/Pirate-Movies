using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IActorRepository
    {
        ICollection<Actor> GetActors();
        Actor GetActor(int id);
        ICollection<Movie> GetActorMovies(int id);
        bool ActorExists(int id);
        bool CreateActor(Actor actor);
        bool UpdateActor(Actor actor);
        bool DeleteActor(Actor actor);
        bool Save();
    }
}
