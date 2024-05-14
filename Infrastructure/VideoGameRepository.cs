using ApplicationCore.Interface;
using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly ApplicationDbContext _context;
        public VideoGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }




        //--------------------------------------
        //
        //  Return one entities
        //
        //--------------------------------------

        public Task<Game> FindGame(int id)
        {
            return _context.game
                .Where(game => game.id == id)
                .Include(game => game.genre)
                .Include(game => game.gamePublishers)
                .FirstAsync();
        }
        public Task<GamePlatform> FindGamePlatform(int id)
        {
            return _context.game_platform
                .Where(game_platform => game_platform.id == id)
                .Include(game_platform => game_platform.platform)
                .Include(game_platform => game_platform.gamePublisher)
                .FirstAsync();
        }
        public Task<GamePublisher> FindGamePublisher(int id)
        {
            return _context.game_publisher
                .Where(game_publisher => game_publisher.id == id)
                .Include(game_publisher => game_publisher.game)
                .Include(game_publisher => game_publisher.publisher)
                .FirstAsync();
        }
        public Task<Genre> FindGenre(int id)
        {
            return _context.genre
                .Where(genre => genre.id == id)
                .Include(genre => genre.games)
                .FirstAsync();
        }
        public Task<Platform> FindPlatform(int id)
        {
            return _context.platform
                .Where(platform => platform.id == id)
                .Include(platform => platform.gamePlatforms)
                .FirstAsync();
        }
        public Task<Publisher> FindPublisher(int id)
        {
            return _context.publisher
                .Where(publisher => publisher.id == id)
                .Include(publisher => publisher.gamePublishers)
                .FirstAsync();
        }
        public Task<Region> FindRegion(int id)
        {
            return _context.region
                .Where(region => region.id == id)
                .Include(r => r.gamePlatforms)
                .FirstAsync();
        }
    


        //--------------------------------------
        //
        //  Return range entities
        //
        //--------------------------------------

        public Task<List<Game>> FindGamePage(int page, int size)
        {
            return _context.game
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(game => game.genre)
                .Include(game => game.gamePublishers)
                .ToListAsync();
        }
        public Task<List<GamePlatform>> FindGamePlatformPage(int page, int size)
        {
            return _context.game_platform
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(game_platform => game_platform.platform)
                .Include(game_platform => game_platform.gamePublisher)
                .ToListAsync();
        }
        public Task<List<GamePublisher>> FindGamePublisherPage(int page, int size)
        {
            return _context.game_publisher
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(game_publisher => game_publisher.game)
                .Include(game_publisher => game_publisher.publisher)
                .ToListAsync();
        }
        public Task<List<Genre>> FindGenrePage(int page, int size)
        {
            return _context.genre
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(genre => genre.games)
                .ToListAsync();
        }
        public Task<List<Platform>> FindPlatformPage(int page, int size)
        {
            return _context.platform
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(platform => platform.gamePlatforms)
                .ToListAsync();
        }
        public Task<List<Publisher>> FindPublisherPage(int page, int size)
        {
            return _context.publisher
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(publisher => publisher.gamePublishers)
                .ToListAsync();
        }
        public Task<List<Region>> FindRegionPage(int page, int size)
        {
            return _context.region
                .Skip(page)
                .Take(size)
                .OrderBy(e => e.id)
                .Include(r => r.gamePlatforms)
                .ToListAsync();
        }
    }
}
