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
            // Category One to Many 
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies) 
                .HasForeignKey(m => m.CategoryId);

            modelBuilder.Entity<Show>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Shows)
                .HasForeignKey(s => s.CategoryId);
            // Country One to Many
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Country)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CountryId);

            modelBuilder.Entity<Show>()
                .HasOne(s => s.Country)
                .WithMany(c => c.Shows)
                .HasForeignKey(s => s.CountryId);
            // Show One to Many
            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Show)
                .WithMany(s => s.Episodes)
                .HasForeignKey(e => e.ShowId);
            // Links One to Many 
            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Links)
                .WithOne(l => l.Episode)
                .HasForeignKey(l => l.EpisodeId)
                .IsRequired(false);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Links)
                .WithOne(l => l.Movie)
                .HasForeignKey(l => l.MovieId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
