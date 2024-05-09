using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using VideoGamesTest.Models;

namespace VideoGamesTest
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<RegionSales>(entity => entity.HasAlternateKey(x => x.region_id));*/


            //
            // Genre - Game 1:m  relation 
            //
            modelBuilder.Entity<Genre>()
                .HasMany(genre => genre.games)
                .WithOne(game => game.genre)
                .HasForeignKey(game => game.genre_id)
                .HasPrincipalKey(genre => genre.id);

            //
            // Game - Game publisher 1:m  relation 
            //
            modelBuilder.Entity<Game>()
                .HasMany(game => game.gamePublishers)
                .WithOne(gamePublisher => gamePublisher.game)
                .HasForeignKey(gamePublisher => gamePublisher.game_id)
                .HasPrincipalKey(game => game.id);

            //
            // Publisher - Game Publisher 1:m  relation 
            //
            modelBuilder.Entity<Publisher>()
                .HasMany(publisher => publisher.gamePublishers)
                .WithOne(gamePublisher => gamePublisher.publisher)
                .HasForeignKey(gamePublisher => gamePublisher.publisher_id)
                .HasPrincipalKey(publisher => publisher.id);





            //
            // GamePublisher - gamePlatform 1:m  relation 
            //
            modelBuilder.Entity<GamePublisher>()
                .HasMany(gamePublisher => gamePublisher.gamePlatforms)
                .WithOne(gamePlatform => gamePlatform.gamePublisher)
                .HasForeignKey(gamePlatform => gamePlatform.game_publisher_id)
                .HasPrincipalKey(gamePublisher => gamePublisher.id);

            //
            // Platform - gamePlatform 1:m  relation 
            //
            modelBuilder.Entity<Platform>()
                .HasMany(platform => platform.gamePlatforms)
                .WithOne(gamePlatform => gamePlatform.platform)
                .HasForeignKey(gamePlatform => gamePlatform.platform_id)
                .HasPrincipalKey(platform => platform.id);





            modelBuilder.Entity<RegionSales>()
                .HasKey(rs => new { rs.region_id, rs.game_platform_id });

            //
            // GamePlatform - regionSales 1:m  relation 
            // 700 000


            modelBuilder.Entity<RegionSales>()
                .HasOne(regionSales => regionSales.GamePlatform)
                .WithMany(gamePlatform => gamePlatform.regionSales)
                .HasForeignKey(regionSales => regionSales.game_platform_id);

            //
            // Region - regionSales 1:m  relation 
            //

            
            modelBuilder.Entity<RegionSales>()
                .HasOne(regionSales => regionSales.Region)
                .WithMany(region => region.regionSales)
                .HasForeignKey(regionSales => regionSales.region_id);
                

        }

        public DbSet<Genre> genre { get; set; }
        public DbSet<Game> game { get; set; }
        public DbSet<Publisher> publisher { get; set; }
        public DbSet<GamePublisher> game_publisher { get; set; }
        public DbSet<Platform> platform { get; set; }
        public DbSet<GamePlatform> game_platform { get; set; }
        public DbSet<Region> region { get; set; }
        public DbSet<RegionSales> region_sales { get; set; }
    }
}
