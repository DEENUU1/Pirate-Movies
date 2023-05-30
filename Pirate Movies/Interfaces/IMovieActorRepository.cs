using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IMovieActorRepository
    {
        MovieActor AssignActorToMovie(int movieId, int actorId);
        MovieActor AssignMovieToActor(int actorId, int movieId);
    }
}
