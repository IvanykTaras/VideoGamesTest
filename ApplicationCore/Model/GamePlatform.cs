using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class GamePlatform
    {
        public int id { get; set; }
        public int game_publisher_id { get; set; }
        public int platform_id { get; set; }
        public int release_year { get; set; }

        public Platform platform { get; set; }
        public GamePublisher gamePublisher { get; set; }
        public ICollection<RegionSales> regionSales { get; set; }
    }
}
