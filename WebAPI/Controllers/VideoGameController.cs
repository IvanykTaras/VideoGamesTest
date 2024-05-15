using ApplicationCore.Interface;
using ApplicationCore.Model;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{

    public class VideoGameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IVideoGameRepository _repository;

        public VideoGameController(IVideoGameRepository repository, ApplicationDbContext context) {
            _context = context;
            _repository = repository;
        }


        [HttpGet("game/{page}/{size}")]
        public Task<List<Game>> GetGames(int page, int size)
        {
            return _repository.FindGamePage(page, size);
        }


        [HttpGet("gamePlatform/{page}/{size}")]
        public Task<List<GamePlatform>> GetGamePlatforms(int page, int size)
        {
            return _repository.FindGamePlatformPage(page,size);
        }

        
        [HttpGet("gamePublisher/{page}/{size}")]
        public Task<List<GamePublisher>> GetGamePublishers(int page, int size)
        {
            return _repository.FindGamePublisherPage(page, size);
        }


        [HttpGet("genre/{page}/{size}")]
        public Task<List<Genre>> GetGenres(int page, int size)
        {
            return _repository.FindGenrePage(page, size);
        }


        [HttpGet("platform/{page}/{size}")]
        public Task<List<Platform>> GetPlatforms(int page, int size)
        {
            return _repository.FindPlatformPage(page, size);
        }


        [HttpGet("publisher/{page}/{size}")]
        public Task<List<Publisher>> GetPublishers(int page, int size)
        {
            return _repository.FindPublisherPage(page, size);
        }


        [HttpGet("region/{page}/{size}")]
        public Task<List<Region>> GetRegions(int page, int size)
        {
            return _repository.FindRegionPage(page, size);
        }

        //==========================================================================
        

        [HttpGet("api/games")]
        public async Task<IActionResult> GetFirstTask([FromQuery] string genre)
        {

            /*Sports*/

            var games =  _context.game
                .Include(g => g.genre)
                .Include(g => g.gamePublishers)
                    .ThenInclude(gp => gp.publisher)
                .Include(g => g.gamePublishers)
                    .ThenInclude(gp => gp.gamePlatforms)
                    .ThenInclude(gpl => gpl.platform)
                .Where(g =>  g.genre.genre_name == genre && g.id < 100)
                .Select(g => new
                {
                    g.id,
                    g.game_name,
                    PublisherName = g.gamePublishers.FirstOrDefault().publisher.publisher_name,
                    GamePlatform = g.gamePublishers.FirstOrDefault().gamePlatforms.FirstOrDefault().platform.platform_name,
                    ReleaseYear = g.gamePublishers.FirstOrDefault().gamePlatforms.FirstOrDefault().release_year,
                })
                .ToListAsync();

            return Ok( await games);
        }

        [HttpGet("/api/games/{id}/sales")]
        public async Task<IActionResult> GetSecondTask(int id)
        {
            var salesData = await _context.game
                .Include(g => g.gamePublishers)
                    .ThenInclude(gpub => gpub.gamePlatforms)
                        .ThenInclude(gpl => gpl.platform)
                .Include(g => g.gamePublishers)
                    .ThenInclude(gpub => gpub.gamePlatforms)
                        .ThenInclude(gpl => gpl.regions)
                .Where( g => g.id == id)
                .Select(g => new
                {
                    gameId = g.id,
                    platformId = g.gamePublishers.FirstOrDefault().gamePlatforms.FirstOrDefault().platform_id,
                    regionId = g.gamePublishers.FirstOrDefault().gamePlatforms.FirstOrDefault().regions.FirstOrDefault().id,
                    sales = 0
                })
                .ToListAsync();

            return Ok(salesData);
        }
      
    }
}
