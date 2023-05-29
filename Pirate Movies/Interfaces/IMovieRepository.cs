using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int id);
        ICollection<Movie> GetMovieByCategory(int categoryId);
        ICollection<Movie> GetMovieByCountry(int countryId);
        ICollection<Link> GetMovieLinks(int movieId);
        bool MovieExists(int id);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
