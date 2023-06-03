using Pirate_Movies.Data;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

namespace Pirate_Movies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;
        public MovieRepository(DataContext context) 
        {
            _context = context;
        }
        public bool CreateMovie(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _context.Remove(movie);
            return Save();
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public ICollection<Actor> GetMovieActors(int id)
        {
            return _context.Movies.Where(m => m.Id == id).SelectMany(m => m.MovieActors).Select(ma => ma.Actor).ToList();

        }

        public ICollection<Link> GetMovieLinks(int id)
        {
            return _context.Movies.Where(m => m.Id == id).SelectMany(m => m.Links).ToList();
        }

        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateMovie(Movie movie)
        {
            _context.Update(movie);
            return Save();
        }

        public bool AddMovieActor(MovieActor movieActor)
        {
            var existingMovieActor = _context.MovieActors.FirstOrDefault(ma => ma.ActorId == movieActor.ActorId && ma.MovieId == movieActor.MovieId);

            if (existingMovieActor != null)
            {
                return true;
            }

            _context.MovieActors.Add(movieActor);
            return Save();
        }
    }
}
