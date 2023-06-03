using Microsoft.EntityFrameworkCore;
using Pirate_Movies.Data;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

namespace Pirate_Movies.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DataContext _context;
        public ActorRepository(DataContext context)
        {
            _context = context;
        }
        public bool ActorExists(int id)
        {
            return _context.Actors.Any(a => a.Id == id);
        }

        public bool CreateActor(Actor actor)
        {
            _context.Add(actor);
            return Save();
        }

        public bool DeleteActor(Actor actor)
        {
            _context.Remove(actor);
            return Save();
        }

        public Actor GetActor(int id)
        {
            return _context.Actors.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Actor> GetActors()
        {
            return _context.Actors.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateActor(Actor actor)
        {
            _context.Update(actor);
            return Save();
        }
    }
}
