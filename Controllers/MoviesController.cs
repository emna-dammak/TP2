using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationdbContext _db;

        public MoviesController(ApplicationdbContext context)
        {
            _db = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
              return _db.movies != null ? 
                          View(await _db.movies.ToListAsync()) :
                          Problem("Entity set 'ApplicationdbContext.movies'  is null.");
        }

        // GET: Movies/Details/5
        [HttpGet("Movie/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.movies == null)
            {
                return NotFound();
            }

            var movie = await _db.movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Add(movie);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.movies == null)
            {
                return NotFound();
            }

            var movie = await _db.movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(movie);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.movies == null)
            {
                return NotFound();
            }

            var movie = await _db.movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.movies == null)
            {
                return Problem("Entity set 'ApplicationdbContext.movies'  is null.");
            }
            var movie = await _db.movies.FindAsync(id);
            if (movie != null)
            {
                _db.movies.Remove(movie);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_db.movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
