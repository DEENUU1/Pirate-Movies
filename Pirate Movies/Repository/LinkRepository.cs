using Pirate_Movies.Data;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

namespace Pirate_Movies.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private readonly DataContext _context;
        public LinkRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateLink(Link link)
        {
            _context.Add(link);
            return Save();
        }

        public bool DeleteLink(Link link)
        {
            _context.Remove(link);
            return Save();
        }

        public Link GetLink(int id)
        {
            return _context.Links.Where(l => l.Id == id).FirstOrDefault();
        }

        public ICollection<Link> GetLinks()
        {
            return _context.Links.ToList();
        }

        public ICollection<Link> GetLinksByMovieId(int movieId)
        {
            return _context.Links.Where(m => m.MovieId == movieId).ToList();
        }

        public bool LinkExist(int Id)
        {
            return _context.Links.Any(c  => c.Id == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLink(Link link)
        {
            _context.Update(link);
            return Save();
        }
    }
}
