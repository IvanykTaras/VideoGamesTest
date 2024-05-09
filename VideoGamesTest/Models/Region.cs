﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VideoGamesTest.Models
{
    public class Region
    { 
        public int id { get; set; }
        public string region_name { get; set; }
        public ICollection<RegionSales> regionSales { get; set; }
    }
}
