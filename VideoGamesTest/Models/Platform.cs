namespace VideoGamesTest.Models
{
    public class Platform
    {
        public int id { get; set; }
        public string platform_name { get; set; }
        public ICollection<GamePlatform> gamePlatforms { get; set; }

    }
}
