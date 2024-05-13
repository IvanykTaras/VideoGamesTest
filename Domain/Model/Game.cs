using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
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
