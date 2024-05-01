using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesTest.Models;

namespace VideoGamesTest.Controllers
{
    [ApiController]
    [Route("/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;


        public WeatherForecastController(ILogger<WeatherForecastController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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

        /*[HttpGet("publisher")]
        public Task<List<Publisher>> GetPublisher()
        {
            var task = _context.publisher.Include( publisher => publisher.).ToListAsync();
            return task;
        }*/
    }
}
