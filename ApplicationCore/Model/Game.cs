using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class Game
    {
        public int id { get; set; }
        public int genre_id { get; set; }
        public string game_name { get; set; }
        public Genre genre { get; set; }

        [JsonIgnore]
        /*[IgnoreDataMember]*/
        public  ICollection<GamePublisher> gamePublishers { get; set; }
    }
}
