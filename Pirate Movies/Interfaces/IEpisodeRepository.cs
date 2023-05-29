using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IEpisodeRepository
    {
        ICollection<Episode> GetEpisodes();
        Show GetEpisode(int id);
        ICollection<Link> GetEpisodeLinks(int EpisodeId);
        bool ShowExists(int id);
        bool CreateShow(Show show);
        bool UpdateShow(Show show);
        bool DeleteShow(Show show);
        bool Save();
    }
}
