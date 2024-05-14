using ApplicationCore.Model;

namespace ApplicationCore.Interface
{
    public interface IVideoGameRepository
    {
        Task<Game> FindGame(int id);
        Task<GamePlatform> FindGamePlatform(int id);
        Task<GamePublisher> FindGamePublisher(int id);
        Task<Genre> FindGenre(int id);
        Task<Platform> FindPlatform(int id);
        Task<Publisher> FindPublisher(int id);
        Task<Region> FindRegion(int id);
        

        Task<List<Game>> FindGamePage(int page, int size);
        Task<List<GamePlatform>> FindGamePlatformPage(int page, int size);
        Task<List<GamePublisher>> FindGamePublisherPage(int page, int size);
        Task<List<Genre>> FindGenrePage(int page, int size);
        Task<List<Platform>> FindPlatformPage(int page, int size);
        Task<List<Publisher>> FindPublisherPage(int page, int size);
        Task<List<Region>> FindRegionPage(int page, int size);
        
    }
}
