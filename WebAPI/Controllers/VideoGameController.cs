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

      
    }
}
