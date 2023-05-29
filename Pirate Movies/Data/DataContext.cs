using Microsoft.EntityFrameworkCore;
using Pirate_Movies.Models;

namespace Pirate_Movies.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Episode> Episodes { get; set;}
        public DbSet<Link> Links { get; set; }  
        public DbSet<Show> Shows { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(movie => movie.CategoryId);

            modelBuilder.Entity<Show>()
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(show => show.CategoryId);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Country)
                .WithMany()
                .HasForeignKey(movie => movie.CountryId);

            modelBuilder.Entity<Show>()
                .HasOne(s => s.Country)
                .WithMany()
                .HasForeignKey(show => show.CountryId);

            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Show)
                .WithMany(s => s.Episodes)
                .HasForeignKey(episode => episode.ShowId);

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Links)
                .WithOne(link => link.Episode)
                .HasForeignKey(link => link.EpisodeId)
                .IsRequired(false);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Links)
                .WithOne(link => link.Movie)
                .HasForeignKey(link => link.MovieId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
