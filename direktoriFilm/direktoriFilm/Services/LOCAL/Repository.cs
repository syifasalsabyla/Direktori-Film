using direktoriFilm.Data;
using direktoriFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace direktoriFilm.Services.LOCAL
{
    public class Repository : IRepository
    {

        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Film> GetSemuaFilm()
        {
            List<Film> results = new List<Film>();

            try
            {
                results = _context.Film.ToList();
            }
            catch (Exception)
            {

                //throw;
            }

            return results;
        }
    }
}
