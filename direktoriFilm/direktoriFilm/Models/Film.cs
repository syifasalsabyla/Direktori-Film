using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace direktoriFilm.Models
{
    public class Film
    {
        public int filmID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
    }
}
