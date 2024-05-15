using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class Genre
    {
        public int id { get; set; }
        public string genre_name { get; set; }

        [JsonIgnore]
        /*[IgnoreDataMember]*/
        public ICollection<Game> games { get; set; }
    }
}
