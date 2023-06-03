using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pirate_Movies.Dto;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;
using Pirate_Movies.Repository;

namespace Pirate_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        public MovieActorController(IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }

        [HttpPost("{movieId}/actors/{actorId}")]
        public IActionResult AddActorToMovie(int movieId, int actorId)
        {
            if (!_movieRepository.MovieExists(movieId))
                return NotFound("Movie not found");

            var movie = _movieRepository.GetMovie(movieId);

            if (!_actorRepository.ActorExists(actorId))
                return NotFound("Actor not found");

            var actor = _actorRepository.GetActor(actorId);

            var movieActor = new MovieActor
            {
                MovieId = movieId,
                ActorId = actorId,
                Movie = movie,
                Actor = actor
            };

            if (!_movieRepository.AddMovieActor(movieActor))
            {
                return StatusCode(500, "Something went wrong while adding actor to the movie");
            }

            return Ok("Actor added to the movie successfully");
        }
    }
}
