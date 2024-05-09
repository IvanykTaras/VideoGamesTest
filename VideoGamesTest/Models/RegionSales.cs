﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGamesTest.Models
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
