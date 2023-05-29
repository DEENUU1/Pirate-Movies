using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int id);
    }
}
