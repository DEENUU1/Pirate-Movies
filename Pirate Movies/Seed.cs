using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pirate_Movies.Data;
using Pirate_Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirate_Movies
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.Categories.Any() || context.Countries.Any() || context.Movies.Any() || context.Links.Any() || context.Actors.Any() || context.MovieActors.Any())
                {
                    return;   // Already seeded
                }



                var actors = new List<Actor>
                {
                    new Actor { FullName = "Elizabeth Olsen" },
                    new Actor { FullName = "Brat Pitt" },
                    new Actor { FullName = "Tony Stark" }
                };
                context.Actors.AddRange(actors);
                context.SaveChanges();

                var categories = new List<Category>
                {
                    new Category { Name = "Action" },
                    new Category { Name = "Comedy" },
                    new Category { Name = "Drama" }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                var countries = new List<Country>
                {
                    new Country { Name = "USA" },
                    new Country { Name = "UK" },
                    new Country { Name = "Canada" }
                };
                context.Countries.AddRange(countries);
                context.SaveChanges();

                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Title = "Movie 1",
                        Description = "Description for Movie 1",
                        DateRelease = DateTime.Now.AddDays(-30),
                        CountryId = countries.Single(c => c.Name == "Canada").Id,
                        CategoryId = categories.Single(c => c.Name == "Action").Id
                    },
                    new Movie
                    {
                        Title = "Movie 2",
                        Description = "Description for Movie 2",
                        DateRelease = DateTime.Now.AddDays(-20),
                        CountryId = countries.Single(c => c.Name == "USA").Id,
                        CategoryId = categories.Single(c => c.Name == "Comedy").Id
                    }
                };
                context.Movies.AddRange(movies);
                context.SaveChanges();

                

                var links = new List<Link>
                {
                    new Link
                    {
                        ServiceName = "Service 1",
                        Url = "http://example.com/link1",
                        Quality = "HD",
                        MovieId = movies.Single(m => m.Title == "Movie 1").Id
                    },
                    new Link
                    {
                        ServiceName = "Service 2",
                        Url = "http://example.com/link2",
                        Quality = "SD",
                        MovieId = movies.Single(m => m.Title == "Movie 2").Id
                    },
                };
                context.Links.AddRange(links);
                context.SaveChanges();

                // Movie Actors
                var movieActors = new List<MovieActor>
                {
                    new MovieActor { ActorId = 1, MovieId = 1 },
                    new MovieActor { ActorId = 2, MovieId = 1 },
                    new MovieActor { ActorId = 3, MovieId = 1 },
                    new MovieActor { ActorId = 1, MovieId = 2 },
                    new MovieActor { ActorId = 2, MovieId = 2 },
                    new MovieActor { ActorId = 1, MovieId = 2 },
                    new MovieActor { ActorId = 2, MovieId = 2 }
            // Add more movie actors here if needed
                };
                context.MovieActors.AddRange(movieActors);
                context.SaveChanges();
            }
        }
    }
}
