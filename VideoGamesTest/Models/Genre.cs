namespace VideoGamesTest.Models
{
    public class Genre
    {
        public int id { get; set; }
        public string genre_name { get; set; }

        public ICollection<Game> games { get; set; }
    }
}
