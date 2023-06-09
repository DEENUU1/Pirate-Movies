﻿using AutoMapper;
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
            CreateMap<ActorDto, Actor>();
            CreateMap<Actor, ActorDto>();
            CreateMap<Link, LinkDto>();
            CreateMap<LinkDto, Link>(); 
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();   
        }

    }
}
