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
    public class DeletedrentalhistoriesController : Controller
    {
        private readonly ModelContext _context;

        public DeletedrentalhistoriesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Deletedrentalhistories
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Deletedrentalhistories.Include(d => d.Car).Include(d => d.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Deletedrentalhistories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deletedrentalhistory = await _context.Deletedrentalhistories
                .Include(d => d.Car)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deletedrentalhistory == null)
            {
                return NotFound();
            }

            return View(deletedrentalhistory);
        }

        // GET: Deletedrentalhistories/Create
        public IActionResult Create()
        {
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status");
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace");
            return View();
        }

        // POST: Deletedrentalhistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Userid,Carid,Rentdate,Returndate,Totalprice")] Deletedrentalhistory deletedrentalhistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deletedrentalhistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status", deletedrentalhistory.Carid);
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace", deletedrentalhistory.Userid);
            return View(deletedrentalhistory);
        }

        // GET: Deletedrentalhistories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deletedrentalhistory = await _context.Deletedrentalhistories.FindAsync(id);
            if (deletedrentalhistory == null)
            {
                return NotFound();
            }
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status", deletedrentalhistory.Carid);
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace", deletedrentalhistory.Userid);
            return View(deletedrentalhistory);
        }

        // POST: Deletedrentalhistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Userid,Carid,Rentdate,Returndate,Totalprice")] Deletedrentalhistory deletedrentalhistory)
        {
            if (id != deletedrentalhistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deletedrentalhistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeletedrentalhistoryExists(deletedrentalhistory.Id))
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
            ViewData["Carid"] = new SelectList(_context.Cars, "Id", "Status", deletedrentalhistory.Carid);
            ViewData["Userid"] = new SelectList(_context.Users, "Id", "Birthplace", deletedrentalhistory.Userid);
            return View(deletedrentalhistory);
        }

        // GET: Deletedrentalhistories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deletedrentalhistory = await _context.Deletedrentalhistories
                .Include(d => d.Car)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deletedrentalhistory == null)
            {
                return NotFound();
            }

            return View(deletedrentalhistory);
        }

        // POST: Deletedrentalhistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var deletedrentalhistory = await _context.Deletedrentalhistories.FindAsync(id);
            _context.Deletedrentalhistories.Remove(deletedrentalhistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeletedrentalhistoryExists(decimal id)
        {
            return _context.Deletedrentalhistories.Any(e => e.Id == id);
        }
    }
}
