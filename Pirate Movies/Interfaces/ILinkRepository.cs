using Pirate_Movies.Models;

namespace Pirate_Movies.Interfaces
{
    public interface ILinkRepository
    {
        ICollection<Link> GetLinks();
        Link GetLink(int id);
        bool LinkExist(int id); 
        bool CreateLink(Link link);
        bool UpdateLink(Link link);
        bool DeleteLink(Link link);
        bool Save();
    }
}
