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
        public DbSet<Link> Links { get; set; }  
        public DbSet<Country> Countries { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category One to Many 
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies) 
                .HasForeignKey(m => m.CategoryId);

            // Country One to Many
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Country)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CountryId);

            // Links One to Many 

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Links)
                .WithOne(l => l.Movie)
                .HasForeignKey(l => l.MovieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // Actors Many to Many
            modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
