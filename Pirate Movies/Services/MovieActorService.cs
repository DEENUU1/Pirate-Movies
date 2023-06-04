using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

public class MovieActorService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IActorRepository _actorRepository;

    public MovieActorService(IMovieRepository movieRepository, IActorRepository actorRepository)
    {
        _movieRepository = movieRepository;
        _actorRepository = actorRepository;
    }

    public void AssignActorToMovie(int actorId, int movieId)
    {
        var actor = _actorRepository.GetActor(actorId);
        var movie = _movieRepository.GetMovie(movieId);

        if (actor != null && movie != null)
        {
            var movieActor = new MovieActor
            {
                ActorId = actor.Id,
                Actor = actor,
                MovieId = movie.Id,
                Movie = movie
            };

            if (movie.MovieActors == null)
            {
                movie.MovieActors = new List<MovieActor>();
            }

            movie.MovieActors.Add(movieActor);

            _movieRepository.Save();
        }
    }

}
