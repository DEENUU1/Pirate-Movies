using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IShowRepository
    {
        ICollection<Show> GetShows();   
        Show GetShow(int id);
        bool ShowCreate(Show show);
        ICollection<Show> GetShowByCategory(int categoryId);
        ICollection<Show> GetShowByCountry(int countryId);
        ICollection<IEpisodeRepository> GetEpisodes(int ShowId);
        bool ShowExists(int id);
        bool Save();
    }
}
