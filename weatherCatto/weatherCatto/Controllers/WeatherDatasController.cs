using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using weatherCatto.Data;
using weatherCatto.Models;

namespace weatherCatto.Controllers
{
    public class WeatherDatasController : Controller
    {
        private readonly ApplicationDBContext _context;

        public WeatherDatasController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: WeatherDatas
        public async Task<IActionResult> Index()
        {
              return _context.weatherDatas != null ? 
                          View(await _context.weatherDatas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.weatherDatas'  is null.");
        }

        // GET: WeatherDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.weatherDatas == null)
            {
                return NotFound();
            }

            var weatherData = await _context.weatherDatas
                .FirstOrDefaultAsync(m => m.WeatherId == id);
            if (weatherData == null)
            {
                return NotFound();
            }

            return View(weatherData);
        }

        // GET: WeatherDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeatherId,Title,Base,Visibility,Dt,Id,Cod")] WeatherData weatherData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherData);
        }

        // GET: WeatherDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.weatherDatas == null)
            {
                return NotFound();
            }

            var weatherData = await _context.weatherDatas.FindAsync(id);
            if (weatherData == null)
            {
                return NotFound();
            }
            return View(weatherData);
        }

        // POST: WeatherDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeatherId,Title,Base,Visibility,Dt,Id,Cod")] WeatherData weatherData)
        {
            if (id != weatherData.WeatherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherDataExists(weatherData.WeatherId))
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
            return View(weatherData);
        }

        // GET: WeatherDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.weatherDatas == null)
            {
                return NotFound();
            }

            var weatherData = await _context.weatherDatas
                .FirstOrDefaultAsync(m => m.WeatherId == id);
            if (weatherData == null)
            {
                return NotFound();
            }

            return View(weatherData);
        }

        // POST: WeatherDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.weatherDatas == null)
            {
                return Problem("Entity set 'ApplicationDBContext.weatherDatas'  is null.");
            }
            var weatherData = await _context.weatherDatas.FindAsync(id);
            if (weatherData != null)
            {
                _context.weatherDatas.Remove(weatherData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherDataExists(int id)
        {
          return (_context.weatherDatas?.Any(e => e.WeatherId == id)).GetValueOrDefault();
        }
    }
}
