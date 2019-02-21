using direktoriFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace direktoriFilm.Services.MLM
{
    public interface IStorage
    {
        List<Film> GetSemuaFilm();
    }
}
