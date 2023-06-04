using Microsoft.AspNetCore.Mvc;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Repository;

namespace Pirate_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorController : ControllerBase
    {
        private readonly MovieActorService _movieActorService;

        public MovieActorController(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }

        [HttpPost]
        public IActionResult AssignActorToMovie(int actorId, int movieId)
        {
            _movieActorService.AssignActorToMovie(actorId, movieId);
            return Ok();
        }

    }
}
