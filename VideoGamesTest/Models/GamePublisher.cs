namespace VideoGamesTest.Models
{
    public class GamePublisher
    {
        public int id { get; set; }
        public int game_id { get; set; }
        public int publisher_id { get; set; }
        public Game game { get; set; }

        public Publisher publisher { get; set; }

    }
}
