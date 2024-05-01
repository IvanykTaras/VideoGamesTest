namespace VideoGamesTest.Models
{
    public class Publisher
    {
        public int id { get; set; }
        public string publisher_name { get; set; }

        public ICollection<GamePublisher> gamePublishers { get; set; }
    }
}
