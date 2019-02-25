using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using direktoriFilm.Data;
using direktoriFilm.Models;
using System.Data.SqlClient;

namespace direktoriFilm.Controllers
{
    public class FilmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Film
        public async Task<IActionResult> Index()
        {
            List <Film> hasilSelect = new List<Film>();
            hasilSelect = _context.Film.FromSql<Film>("exec selectFilm").ToList();
            return View(hasilSelect);
            //format awalnya jadikan komentar //return View(await _context.Film.ToListAsync());
        }

        // GET: Film/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Film/Create
        public IActionResult Create()
        {

           // List<Film> hasilInsert = new List<Film>();
           // hasilInsert = _context.Film.FromSql<Film>("exec insertFilm").ToList();
            //return View(hasilInsert);
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Genre,Year,Date")] Film film)
           // public async Task<IActionResult> Edit(int id, [Bind("filmID,Name,Genre,Year")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlCommand("exec insertFilm @Name,@Genre,@Year,@Date",
                  new SqlParameter("Name", film.Name),
                  new SqlParameter("Genre", film.Genre),
                  new SqlParameter("Year", film.Year),
                  new SqlParameter("Date", film.Date));

                return RedirectToAction("Index");
            }
            return View(film);
        }
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        _context.Add(film);
        ////        await _context.SaveChangesAsync();
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    return View(film);
        ////}

        // GET: Film/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
            //List<Film> hasilUpdate = new List<Film>();
            //hasilUpdate = _context.Film.FromSql<Film>("exec updateFilm").ToList();
            //return View(hasilUpdate);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmId,Name,Genre,Year,Date")] Film film)
        {
            if (id != film.FilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlCommand("exec updateFilm @FilmId,@Name,@Genre,@Year,@Date",
                 new SqlParameter("FilmId", film.FilmId),
                 new SqlParameter("Name", film.Name),
                 new SqlParameter("Genre", film.Genre),
                 new SqlParameter("Year", film.Year),
                 new SqlParameter("Date", film.Date));

                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Film/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            //this.Film.SqlQuery<Film>("exec deleteFilm @FilmId , @Name, @Genre, @Year", filmID, Name, Genre, Year);
            //List<Film> hasilDelete = new List<Film>();
            //hasilDelete = _context.Film.FromSql<Film>("exec deleteFilm").ToList();
            //return View(hasilDelete);
            //FilmController db = FilmController baru();
            //IList<Film> empSummary = db.FilmController.SqlQuery<Film>("deleteFilm").ToList();
            //_context.Film.FromSql("deleteFilm").ToList();
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Database.ExecuteSqlCommand("exec deleteFilm @FilmId",
                    new SqlParameter("FilmId", id));
           // var film = await _context.Film.FindAsync(id);
          //  _context.Film.Remove(film);
           // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.FilmId == id);
        }
    }
}
