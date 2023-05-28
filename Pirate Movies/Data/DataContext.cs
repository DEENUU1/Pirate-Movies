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
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<SeasonShow> SeasonShows { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }
        public DbSet<EpisodeLink> EpisodeLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>() // Movie and Category One to One
                .HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.Category);
            modelBuilder.Entity<Show>() // Show and Category One to One 
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.Category);

            modelBuilder.Entity<Episode>() // Episode and Season One to One
                .HasOne(e => e.Season)
                .WithMany()
                .HasForeignKey(e => e.Season);

            modelBuilder.Entity<Episode>() // Episode and Show One to One 
                .HasOne(e => e.Show)
                .WithMany()
                .HasForeignKey(e => e.Show);
            // SeasonShow and Show Many to Many 
            modelBuilder.Entity<SeasonShow>()
                .HasKey(ss => new { ss.ShowId, ss.SeasonId });

            modelBuilder.Entity<SeasonShow>()
                .HasOne(ss => ss.Show)
                .WithMany(s => s.SeasonShows)
                .HasForeignKey(ss => ss.ShowId);

            modelBuilder.Entity<SeasonShow>()
                .HasOne(ss => ss.Season)
                .WithMany(s => s.SeasonShows)
                .HasForeignKey(ss => ss.SeasonId);

            // Link and Movie Many to One 
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.MovieLinks)
                .WithOne(ml => ml.Movie)
                .HasForeignKey(ml => ml.MovieId);

            modelBuilder.Entity<Link>()
                .HasMany(l => l.MovieLinks)
                .WithOne(ml => ml.Link)
                .HasForeignKey(ml => ml.LinkId);

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.EpisodeLinks)
                .WithOne(el => el.Episode)
                .HasForeignKey(el => el.EpisodeId);

            modelBuilder.Entity<Link>()
                .HasMany(l => l.EpisodeLinks)
                .WithOne(el => el.Link)
                .HasForeignKey(el => el.LinkId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
