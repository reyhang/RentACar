using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class RentalhistoriesController : Controller
    {
        private readonly ModelContext _context;

        public RentalhistoriesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Rentalhistories
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Rentalhistories.Include(r => r.Car).Include(r => r.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Rentalhistories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalhistory = await _context.Rentalhistories
                .Include(r => r.Car)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalhistory == null)
            {
                return NotFound();
            }

            return View(rentalhistory);
        }

        // GET: Rentalhistories/Create
        public IActionResult Create()
        {
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status");
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace");
            return View();
        }

        // POST: Rentalhistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Userid,Carid,Rentdate,Returndate,Totalprice")] Rentalhistory rentalhistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalhistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status", rentalhistory.Carid);
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace", rentalhistory.Userid);
            return View(rentalhistory);
        }

        // GET: Rentalhistories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalhistory = await _context.Rentalhistories.FindAsync(id);
            if (rentalhistory == null)
            {
                return NotFound();
            }
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status", rentalhistory.Carid);
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace", rentalhistory.Userid);
            return View(rentalhistory);
        }

        // POST: Rentalhistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Userid,Carid,Rentdate,Returndate,Totalprice")] Rentalhistory rentalhistory)
        {
            if (id != rentalhistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalhistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalhistoryExists(rentalhistory.Id))
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
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status", rentalhistory.Carid);
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace", rentalhistory.Userid);
            return View(rentalhistory);
        }

        // GET: Rentalhistories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalhistory = await _context.Rentalhistories
                .Include(r => r.Car)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalhistory == null)
            {
                return NotFound();
            }

            return View(rentalhistory);
        }

        // POST: Rentalhistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var rentalhistory = await _context.Rentalhistories.FindAsync(id);
            _context.Rentalhistories.Remove(rentalhistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalhistoryExists(decimal id)
        {
            return _context.Rentalhistories.Any(e => e.Id == id);
        }
    }
}
