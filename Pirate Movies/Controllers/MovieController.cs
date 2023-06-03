using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pirate_Movies.Data;
using Pirate_Movies.Dto;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Models;
using Pirate_Movies.Repository;

namespace Pirate_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetMovies() 
        {
            var movies = _movieRepository.GetMovies();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            if (!_movieRepository.MovieExists(id))
                return NotFound();
            var movie = _movieRepository.GetMovie(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieDto movieCreate)
        {
            if (movieCreate == null)
                return BadRequest(ModelState);

            var category = _movieRepository.GetMovies()
                .Where(c => c.Title.Trim().ToUpper() == movieCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Movie already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieMap = _mapper.Map<Movie>(movieCreate);

            if (!_movieRepository.CreateMovie(movieMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (!_movieRepository.MovieExists(id))
            {
                return NotFound();
            }

            var movieToDelete = _movieRepository.GetMovie(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_movieRepository.DeleteMovie(movieToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting movie");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieDto updateMovie)
        {
            if (updateMovie == null)
                return BadRequest(ModelState);

            if (id != updateMovie.Id)
                return BadRequest(ModelState);

            if (!_movieRepository.MovieExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var movieMap = _mapper.Map<Movie>(updateMovie);

            if (!_movieRepository.UpdateMovie(movieMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("{id}/actors")]
        public IActionResult GetActorMovies(int id)
        {
            if (!_movieRepository.MovieExists(id))
                return NotFound();

            var movieActors = _movieRepository.GetMovieActors(id);
            if (movieActors == null)
                return NotFound();

            return Ok(movieActors);
        }

        [HttpGet("{id}/links")]
        public IActionResult GetMovieLinks(int id)
        {
            if (!_movieRepository.MovieExists(id))
                return NotFound();

            var movieLinks = _movieRepository.GetMovieLinks(id);
            if (movieLinks == null)
                return NotFound();

            return Ok(movieLinks);
        }



    }
}
