using Domain.Model;

namespace ApplicationCore.Interface
{
    public interface IVideoGameRepository
    {

        Task<List<Game>> FindAllGames();
        Task<List<GamePlatform>> FindAllGamePlatforms();
        Task<List<GamePublisher>> FindAllGamePublishers();
        Task<List<Genre>> FindAllGenres();
        Task<List<Platform>> FindAllPlatforms();
        Task<List<Publisher>> FindAllPublishers();
        Task<List<Region>> FindAllRegions();
        Task<List<RegionSales>> FindAllRegionSales();


        Task<Game> FindGame(int id);
        Task<GamePlatform> FindGamePlatform(int id);
        Task<GamePublisher> FindGamePublisher(int id);
        Task<Genre> FindGenre(int id);
        Task<Platform> FindPlatform(int id);
        Task<Publisher> FindPublisher(int id);
        Task<Region> FindRegion(int id);
        Task<RegionSales> FindRegionSales(int region_id, int game_platform_id);


        Task<List<Game>> FindGamePage(int page, int size);
        Task<List<GamePlatform>> FindGamePlatformPage(int page, int size);
        Task<List<GamePublisher>> FindGamePublisherPage(int page, int size);
        Task<List<Genre>> FindGenrePage(int page, int size);
        Task<List<Platform>> FindPlatformPage(int page, int size);
        Task<List<Publisher>> FindPublisherPage(int page, int size);
        Task<List<Region>> FindRegionPage(int page, int size);
        Task<List<RegionSales>> FindRegionSalesPage(int region_id, int game_platform_id);
        
    }
}
