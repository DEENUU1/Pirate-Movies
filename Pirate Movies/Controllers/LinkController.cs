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
    public class LinkController : ControllerBase
    {
        private readonly ILinkRepository _linkRepository;
        private readonly IMapper _mapper;
        public LinkController(ILinkRepository linkRepository, IMapper mapper)
        {
            _linkRepository = linkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLinks()
        {
            var links = _linkRepository.GetLinks();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(links);
        }

        [HttpGet("{id}")]
        public IActionResult GetLink(int id)
        {
            if (!_linkRepository.LinkExist(id))
            {
                return NotFound();
            }

            var link = _linkRepository.GetLink(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(link);
        }

        [HttpGet("movie/{movieId}")]
        public IActionResult GetLinkByMovie(int movieId)
        {
            var links = _linkRepository.GetLinksByMovieId(movieId);
            if (links == null || links.Count == 0)
            {
                return NotFound();
            }
            return Ok(links);   
        }

        [HttpPost]
        public IActionResult CreateLink([FromBody] LinkDto linkCreate)
        {
            if (linkCreate == null)
                return BadRequest(ModelState);

            var link = _linkRepository.GetLinks()
                .Where(c => c.ServiceName.Trim().ToUpper() == linkCreate.ServiceName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (link != null)
            {
                ModelState.AddModelError("", "Link already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var linkMap = _mapper.Map<Link>(linkCreate);

            if (!_linkRepository.CreateLink(linkMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLink(int id)
        {
            if (!_linkRepository.LinkExist(id))
            {
                return NotFound();
            }

            var linkToDelete = _linkRepository.GetLink(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_linkRepository.DeleteLink(linkToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting link");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLink(int id, [FromBody] LinkDto updateLink)
        {
            if (updateLink == null)
                return BadRequest(ModelState);

            if (id != updateLink.Id)
                return BadRequest(ModelState);

            if (!_linkRepository.LinkExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var linkMap = _mapper.Map<Link>(updateLink);

            if (!_linkRepository.UpdateLink(linkMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
