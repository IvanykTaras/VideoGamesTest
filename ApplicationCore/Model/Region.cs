using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class Region
    {
        public int id { get; set; }
        public string region_name { get; set; }

        [JsonIgnore]
        public ICollection<GamePlatform> gamePlatforms { get; set; }
        /*public ICollection<RegionSales> regionSales { get; set; }*/ 
    }
}
