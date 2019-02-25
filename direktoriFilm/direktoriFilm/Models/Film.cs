using System;
using System.Collections.Generic;
using System.Data;

namespace direktoriFilm.Models
{
    public partial class Film
    {
     

        public int FilmId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
    }
}
