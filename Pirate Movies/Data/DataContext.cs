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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.Category);
            modelBuilder.Entity<Show>()
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.Category);
        
            base.OnModelCreating(modelBuilder);
        }
    }
}
