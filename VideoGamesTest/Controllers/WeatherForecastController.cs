using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesTest.Models;

namespace VideoGamesTest.Controllers
{
    [ApiController]
    [Route("/weather")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;


        public WeatherForecastController(ILogger<WeatherForecastController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("genre")]
        public Task<List<Genre>> GetGenre()
        {
            Task<List<Genre>> task = _context.genre.Include(genre => genre.games).ToListAsync();
            return task;
        }

        [HttpGet("game")]
        public Task<List<Game>> GetGame()
        {
            var task = _context.game
                .Where(e => e.id < 100)
                .Include(game => game.genre)
                .Include(game => game.gamePublishers)
                .ToListAsync();
            return task;
        }

        [HttpGet("gamePublisher")]
        public Task<List<GamePublisher>> GetGamePublisher()
        {
            var task = _context.game_publisher
                .Where(e=> e.id < 10)
                .Include(game_publisher => game_publisher.game)
                .Include(game_publisher => game_publisher.publisher)
                .ToListAsync();
            return task;
        }

        [HttpGet("publisher")]
        public Task<List<Publisher>> GetPublisher()
        {
            var task = _context.publisher
                .Where(e => e.id < 10)
                .Include(e => e.gamePublishers)
                .ToListAsync();
            return task;
        }

        [HttpGet("Platform")]
        public Task<List<Platform>> GetPlatform()
        {
            var task = _context.platform.ToListAsync();
            return task;
        }

        [HttpGet("GamePlatform")]
        public Task<List<GamePlatform>> GetGamePlatform()
        {
            var task = _context.game_platform
                .Where( gp => gp.id < 10)
                .Include(game_platform => game_platform.platform)
                .Include(game_platform => game_platform.gamePublisher)
                .Include(game_platform => game_platform.regionSales)
                .ToListAsync();
            return task;
        }

        [HttpGet("Region")]
        public Task<List<Region>> GetRegions()
        {
            var task = _context.region.Where(e=>e.id<10).Include(region => region.regionSales).ToListAsync();
            return task;
        }

        [HttpGet("RegionSales")]
        public Task<List<RegionSales>> GetRegionSales()
        {
            var task = _context.region_sales.Include(rs => rs.GamePlatform).Include(rs => rs.Region).ToListAsync();
            return task;
        }

        [HttpGet("getroutedata/{page}/{user}")]
        public List<string> GetString([FromRoute] int? page, [FromRoute] int user, [FromBody] string someData)
        {
            var a = new List<string>() { $"page:{page}, user: {user}, someData: {someData}", "" };
            return a;
        }

    }
}
