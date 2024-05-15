using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class Publisher
    {
        public int id { get; set; }
        public string publisher_name { get; set; }

        [JsonIgnore]
        /*[IgnoreDataMember]*/
        public ICollection<GamePublisher> gamePublishers { get; set; }
    }
}
