using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Filter;
using RentACar.Models;

namespace RentACar.Controllers
{

    public class CarsController : Controller
    {
        private readonly ModelContext _context;

        public CarsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Cars.Include(c => c.Brand).Include(c => c.Color).Include(c => c.Model);
            return View(await modelContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Id");
            ViewData["Colorid"] = new SelectList(_context.Colors, "Id", "Id");
            ViewData["Modelid"] = new SelectList(_context.Models, "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brandid,Modelid,Colorid,Status,Plate,Dailyprice")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Id", car.Brandid);
            ViewData["Colorid"] = new SelectList(_context.Colors, "Id", "Id", car.Colorid);
            ViewData["Modelid"] = new SelectList(_context.Models, "Id", "Id", car.Modelid);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Id", car.Brandid);
            ViewData["Colorid"] = new SelectList(_context.Colors, "Id", "Id", car.Colorid);
            ViewData["Modelid"] = new SelectList(_context.Models, "Id", "Id", car.Modelid);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Brandid,Modelid,Colorid,Status,Plate,Dailyprice")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Id", car.Brandid);
            ViewData["Colorid"] = new SelectList(_context.Colors, "Id", "Id", car.Colorid);
            ViewData["Modelid"] = new SelectList(_context.Models, "Id", "Id", car.Modelid);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(decimal id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
