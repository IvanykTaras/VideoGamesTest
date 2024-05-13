using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Region
    {
        public int id { get; set; }
        public string region_name { get; set; }
        public ICollection<RegionSales> regionSales { get; set; }
    }
}
