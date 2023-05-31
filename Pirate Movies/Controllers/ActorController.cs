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
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorController(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            var actors = _actorRepository.GetActors();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public IActionResult GetActor(int id)
        {
            if (!_actorRepository.ActorExists(id))
                return NotFound(); 
            var actor = _actorRepository.GetActor(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actor);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] ActorDto actorCreate)
        {
            if (actorCreate == null)
                return BadRequest(ModelState);

            var category = _actorRepository.GetActors()
                .Where(c => c.FullName.Trim().ToUpper() == actorCreate.FullName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Actor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actorMap = _mapper.Map<Actor>(actorCreate);

            if (!_actorRepository.CreateActor(actorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            if (!_actorRepository.ActorExists(id))
            {
                return NotFound();
            }

            var categoryToDelete = _actorRepository.GetActor(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_actorRepository.DeleteActor(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting actor");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] ActorDto updatedActor)
        {
            if (updatedActor == null)
                return BadRequest(ModelState);

            if (id != updatedActor.Id)
                return BadRequest(ModelState);

            if (!_actorRepository.ActorExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var actorMap = _mapper.Map<Actor>(updatedActor);

            if (!_actorRepository.UpdateActor(actorMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("{id}/movies")]
        public IActionResult GetActorMovies(int id)
        {
            if (!_actorRepository.ActorExists(id))
                return NotFound();

            var actorMovie = _actorRepository.GetActorMovies(id);
            if (actorMovie == null)
                return NotFound();

            return Ok(actorMovie);
        }
    
    }
}
