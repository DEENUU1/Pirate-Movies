using AutoMapper;
using Pirate_Movies.Dto;
using Pirate_Movies.Models;

namespace Pirate_Movies.Helper
{
    public class MappingProfiles : Profile 
    {
        public MappingProfiles() 
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
        }

    }
}
