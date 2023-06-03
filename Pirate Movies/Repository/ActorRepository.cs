using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pirate_Movies.Data;
using Pirate_Movies.Dto;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

namespace Pirate_Movies.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ActorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            return _context.Actors.FirstOrDefault(a => a.Id == id);

        }

        public ICollection<ActorDto> GetActors()
        {
            var actors = _context.Actors.Include(a => a.MovieActors).ToList();
            var actorDtos = _mapper.Map<ICollection<ActorDto>>(actors);
            return actorDtos;
        }

        public ICollection<MovieDto> GetMoviesByActorId(int actorId)
        {
            var actor = _context.Actors
                .Include(a => a.MovieActors)
                .ThenInclude(ma => ma.Movie)
                .FirstOrDefault(a => a.Id == actorId);

            if (actor == null)
                return null;

            var movies = actor.MovieActors.Select(ma => ma.Movie).ToList();
            var movieDtos = _mapper.Map<ICollection<MovieDto>>(movies);
            return movieDtos;
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
