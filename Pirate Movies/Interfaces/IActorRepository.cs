using Pirate_Movies.Dto;
using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IActorRepository
    {
        ICollection<ActorDto> GetActors();
        Actor GetActor(int id);
        bool ActorExists(int id);
        bool CreateActor(Actor actor);
        bool UpdateActor(Actor actor);
        bool DeleteActor(Actor actor);
        bool Save();
        ICollection<MovieDto> GetMoviesByActorId(int actorId);
    }
}
