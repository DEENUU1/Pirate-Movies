using Pirate_Movies.Data;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

namespace Pirate_Movies.Repository
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly DataContext _context;
        public MovieActorRepository(DataContext context) 
        {
            _context = context;
        }

        public MovieActor AssignActorToMovie(int movieId, int actorId)
        {
            var movieActor = new MovieActor
            {
                MovieId = movieId,
                ActorId = actorId
            };

            _context.MovieActors.Add(movieActor);   
            _context.SaveChanges();
            return movieActor;
        }

        public MovieActor AssignMovieToActor(int actorId, int movieId)
        {
            var movieActor = new MovieActor
            {
                MovieId = movieId,
                ActorId = actorId
            };

            _context.MovieActors.Add(movieActor);   
            _context.SaveChanges();

            return movieActor;
        }
    }
}
