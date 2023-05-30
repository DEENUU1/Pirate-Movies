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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var country = _countryRepository.GetCountries();    
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(country); 
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {
            if (!_countryRepository.CountryExists(id))
                return NotFound();

            var category = _countryRepository.GetCountry(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);

            var category = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(countryCreate);

            if (!_countryRepository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            if (!_countryRepository.CountryExists(id))
            {
                return NotFound();
            }

            var countryToDelete = _countryRepository.GetCountry(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryRepository.DeleteCountry(countryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting category");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] CountryDto updateCountry)
        {
            if (updateCountry == null)
                return BadRequest(ModelState);

            if (id != updateCountry.Id)
                return BadRequest(ModelState);

            if (!_countryRepository.CountryExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var countryMap = _mapper.Map<Country>(updateCountry);

            if (!_countryRepository.UpdateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
