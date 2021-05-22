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
    public class AdmİnController : Controller
    {
        private readonly ModelContext _context;

        public AdmİnController(ModelContext context)
        {
            _context = context;
        }

        // GET: Admİn
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admİns.ToListAsync());
        }

        // GET: Admİn/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admİn = await _context.Admİns
                .FirstOrDefaultAsync(m => m.Name == id);
            if (admİn == null)
            {
                return NotFound();
            }

            return View(admİn);
        }

        // GET: Admİn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admİn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Emaİl,Password,Id")] Admİn admİn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admİn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admİn);
        }

        // GET: Admİn/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admİn = await _context.Admİns.FindAsync(id);
            if (admİn == null)
            {
                return NotFound();
            }
            return View(admİn);
        }

        // POST: Admİn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Surname,Emaİl,Password,Id")] Admİn admİn)
        {
            if (id != admİn.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admİn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmİnExists(admİn.Name))
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
            return View(admİn);
        }

        // GET: Admİn/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admİn = await _context.Admİns
                .FirstOrDefaultAsync(m => m.Name == id);
            if (admİn == null)
            {
                return NotFound();
            }

            return View(admİn);
        }

        // POST: Admİn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admİn = await _context.Admİns.FindAsync(id);
            _context.Admİns.Remove(admİn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmİnExists(string id)
        {
            return _context.Admİns.Any(e => e.Name == id);
        }
    }
}
