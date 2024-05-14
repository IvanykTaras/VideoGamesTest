using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            /*source.Skip(startIndex).Take(pageSize)*/

            //
            // Genre - Game 1:m  relation 
            //
            modelBuilder.Entity<Genre>()
                .HasMany(genre => genre.games)
                .WithOne(game => game.genre)
                .HasForeignKey(game => game.genre_id);
            /*.HasPrincipalKey(genre => genre.id);*/

            //
            // Game - Game publisher 1:m  relation 
            //
            modelBuilder.Entity<Game>()
                .HasMany(game => game.gamePublishers)
                .WithOne(gamePublisher => gamePublisher.game)
                .HasForeignKey(gamePublisher => gamePublisher.game_id);
            /*.HasPrincipalKey(game => game.id);*/

            //
            // Publisher - Game Publisher 1:m  relation 
            //
            modelBuilder.Entity<Publisher>()
                .HasMany(publisher => publisher.gamePublishers)
                .WithOne(gamePublisher => gamePublisher.publisher)
                .HasForeignKey(gamePublisher => gamePublisher.publisher_id);
            /*.HasPrincipalKey(publisher => publisher.id);*/





            //
            // GamePublisher - gamePlatform 1:m  relation 
            //
            modelBuilder.Entity<GamePublisher>()
                .HasMany(gamePublisher => gamePublisher.gamePlatforms)
                .WithOne(gamePlatform => gamePlatform.gamePublisher)
                .HasForeignKey(gamePlatform => gamePlatform.game_publisher_id);
            /*.HasPrincipalKey(gamePublisher => gamePublisher.id);*/

            //
            // Platform - gamePlatform 1:m  relation 
            //
            modelBuilder.Entity<Platform>()
                .HasMany(platform => platform.gamePlatforms)
                .WithOne(gamePlatform => gamePlatform.platform)
                .HasForeignKey(gamePlatform => gamePlatform.platform_id);
                






            modelBuilder.Entity<Region>()
                .HasMany(reg => reg.gamePlatforms)
                .WithMany(gp => gp.regions)
                .UsingEntity<RegionSales>(
                    rs => rs.HasOne(rs => rs.GamePlatform).WithMany().HasForeignKey(rs => rs.game_platform_id),
                    rs => rs.HasOne(rs => rs.Region).WithMany().HasForeignKey(rs => rs.region_id),
                    rs =>
                    {
                        rs.HasKey(rs => new { rs.game_platform_id, rs.region_id});
                    }
                );
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
