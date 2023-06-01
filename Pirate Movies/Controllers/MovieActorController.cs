using Microsoft.AspNetCore.Mvc;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;

namespace Pirate_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorController : ControllerBase
    {
        private readonly IMovieActorRepository _movieActorRepository;

        public MovieActorController(IMovieActorRepository movieActorRepository)
        {
            _movieActorRepository = movieActorRepository;
        }

        [HttpPost("assign-actor-to-movie")]
        public IActionResult AssignActorToMovie(int movieId, int actorId)
        {
            var movieActor = _movieActorRepository.AssignActorToMovie(movieId, actorId);

            if (movieActor == null)
            {
                return BadRequest("Failed to assign actor to movie.");
            }

            return Ok(movieActor);
        }

        [HttpPost("assign-movie-to-actor")]
        public IActionResult AssignMovieToActor(int actorId, int movieId)
        {
            var movieActor = _movieActorRepository.AssignMovieToActor(actorId, movieId);

            if (movieActor == null)
            {
                return BadRequest("Failed to assign movie to actor.");
            }

            return Ok(movieActor);
        }
    }
}
