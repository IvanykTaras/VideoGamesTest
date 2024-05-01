namespace VideoGamesTest.Models
{
    public class Game
    {
        public int id { get; set; }
        public int genre_id { get; set; }
        public string game_name { get; set; }
        public Genre genre { get; set; }
        public ICollection<GamePublisher> gamePublishers { get; set; }
    }
}
