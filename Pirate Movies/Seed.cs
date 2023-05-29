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
                if (context.Categories.Any() || context.Countries.Any() || context.Shows.Any() || context.Movies.Any() || context.Episodes.Any() || context.Links.Any() )
                {
                    return;   // Already seeded
                }

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

                var shows = new List<Show>
                {
                    new Show
                    {
                        Title = "Show 1",
                        Description = "Description for Show 1",
                        DateRelease = DateTime.Now.AddDays(-10),
                        CountryId = countries.Single(c => c.Name == "USA").Id,
                        CategoryId = categories.Single(c => c.Name == "Drama").Id
                    },
                    new Show
                    {
                        Title = "Show 2",
                        Description = "Description for Show 2",
                        DateRelease = DateTime.Now.AddDays(-5),
                        CountryId = countries.Single(c => c.Name == "UK").Id,
                        CategoryId = categories.Single(c => c.Name == "Action").Id
                    }
                };
                context.Shows.AddRange(shows);
                context.SaveChanges();

                var episodes = new List<Episode>
                {
                    new Episode
                    {
                        Number = 1,
                        Title = "Episode 1",
                        ShowId = shows.Single(s => s.Title == "Show 1").Id
                    },
                    new Episode
                    {
                        Number = 2,
                        Title = "Episode 2",
                        ShowId = shows.Single(s => s.Title == "Show 1").Id
                    },
                    new Episode
                    {
                        Number = 1,
                        Title = "Episode 1",
                        ShowId = shows.Single(s => s.Title == "Show 2").Id
                    },
                    new Episode
                    {
                        Number = 2,
                        Title = "Episode 2",
                        ShowId = shows.Single(s => s.Title == "Show 2").Id
                    }
                };
                context.Episodes.AddRange(episodes);
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
                    new Link
                    {
                        ServiceName = "Service 1",
                        Url = "http://example.com/link3",
                        Quality = "HD",
                        EpisodeId = episodes.Single(e => e.Title == "Episode 1" && e.ShowId == shows.Single(s => s.Title == "Show 1").Id).Id
                    },
                    new Link
                    {
                        ServiceName = "Service 2",
                        Url = "http://example.com/link4",
                        Quality = "SD",
                        EpisodeId = episodes.Single(e => e.Title == "Episode 2" && e.ShowId == shows.Single(s => s.Title == "Show 1").Id).Id
                    }
                };
                context.Links.AddRange(links);
                context.SaveChanges();
            }
        }
    }
}
