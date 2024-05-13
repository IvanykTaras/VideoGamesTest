using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Platform
    {
        public int id { get; set; }
        public string platform_name { get; set; }
        public ICollection<GamePlatform> gamePlatforms { get; set; }
    }
}
