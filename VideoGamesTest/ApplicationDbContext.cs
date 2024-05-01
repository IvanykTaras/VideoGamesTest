using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using VideoGamesTest.Models;

namespace VideoGamesTest
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // Genre - Game 1:m  relation 
            //
            modelBuilder.Entity<Genre>()
                .HasMany(genre => genre.games)
                .WithOne(game => game.genre)
                .HasForeignKey(game => game.genre_id)
                .HasPrincipalKey(genre => genre.id);

            //
            // Genre - Game 1:m  relation 
            //
            modelBuilder.Entity<Game>()
                .HasMany(game => game.gamePublishers)
                .WithOne(gamePublisher => gamePublisher.game)
                .HasForeignKey(gamePublisher => gamePublisher.game_id)
                .HasPrincipalKey(game => game.id);

            //
            // Genre - Game 1:m  relation 
            //
            modelBuilder.Entity<Publisher>()
                .HasMany(publisher => publisher.gamePublishers)
                .WithOne(gamePublisher => gamePublisher.publisher)
                .HasForeignKey(gamePublisher => gamePublisher.publisher_id)
                .HasPrincipalKey(publisher => publisher.id);
        }

        public DbSet<Genre> genre { get; set; }
        public DbSet<Game> game { get; set; }
        public DbSet<Publisher> publisher { get; set; }
        public DbSet<GamePublisher> game_publisher { get; set; }


        public DbSet<Region> region { get; set; }
        public DbSet<RegionSales> region_sales { get; set; }
    }
}
