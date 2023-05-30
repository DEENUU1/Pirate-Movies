using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int id);
        ICollection<Link> GetMovieLinks(int id);
        ICollection<Actor> GetMovieActors(int id);
        bool MovieExists(int id);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
