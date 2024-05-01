using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGamesTest.Models
{
    [Keyless]
    public class RegionSales
    {

        public int RegionId { get; set; }
        public int GamePlatformId { get; set; }
        public int NumSales { get; set; }

    }
}
