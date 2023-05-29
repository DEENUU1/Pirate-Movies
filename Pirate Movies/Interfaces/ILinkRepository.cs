using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface ILinkRepository
    {
        ICollection<Link> GetLinks();
        Link GetLink(int id);
        ICollection<Link> GetLinksByMovieId(int movieId);
        ICollection<Link> GetLinksByEpisodeId(int episodeId);
    }
}
