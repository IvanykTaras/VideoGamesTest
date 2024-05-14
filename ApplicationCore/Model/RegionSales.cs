using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class RegionSales
    {
        public int region_id { get; set; }
        public int game_platform_id { get; set; }
        public int num_sales { get; set; }
        public Region Region { get; set; }
        public GamePlatform GamePlatform { get; set; }
    }
}
