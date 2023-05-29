using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface IEpisodeRepository
    {
        ICollection<Episode> GetEpisodes();
        Show GetEpisode(int id);
        bool EpisodeCreate(Episode episode);
        ICollection<Link> GetEpisodeLinks(int EpisodeId);
        bool ShowExists(int id);
        bool Save();
    }
}
