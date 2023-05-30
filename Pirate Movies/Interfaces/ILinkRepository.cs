using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface ILinkRepository
    {
        ICollection<Link> GetLinks();
        Link GetLink(int id);
        ICollection<Link> GetLinksByMovieId(int movieId);
        ICollection<Link> GetLinksByEpisodeId(int episodeId);
        bool LinkExist(Link link); 
        bool CreateLink(Link link);
        bool UpdateLink(Link link);
        bool DeleteLink(Link link);
        bool Save();
    }
}
