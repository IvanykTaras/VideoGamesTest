using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Genre
    {
        public int id { get; set; }
        public string genre_name { get; set; }
        public ICollection<Game> games { get; set; }
    }
}
