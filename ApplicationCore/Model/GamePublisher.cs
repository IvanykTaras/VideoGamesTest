using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class GamePublisher
    {
        public int id { get; set; }
        public int game_id { get; set; }
        public int publisher_id { get; set; }
        public Game game { get; set; }
        public Publisher publisher { get; set; }

        [JsonIgnore]
        /*[IgnoreDataMember]*/
        public  ICollection<GamePlatform> gamePlatforms { get; set; }
    }
}
