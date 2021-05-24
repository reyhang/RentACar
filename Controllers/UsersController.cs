﻿using System;
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
   
    public class UsersController : Controller
    {
        private readonly ModelContext _context;

        public UsersController(ModelContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Users.Include(u => u.Address).Include(u => u.Card).Include(u => u.Contact);
            return View(await modelContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Card)
                .Include(u => u.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["Addressid"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["Cardid"] = new SelectList(_context.Cards, "Id", "Cardnumber");
            ViewData["Contactid"] = new SelectList(_context.Contacts, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Contactid,Addressid,Cardid,Nationalid,Firstname,Lastname,Birthplace,Birthyear")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Addressid"] = new SelectList(_context.Addresses, "Id", "Id", user.Addressid);
            ViewData["Cardid"] = new SelectList(_context.Cards, "Id", "Cardnumber", user.Cardid);
            ViewData["Contactid"] = new SelectList(_context.Contacts, "Id", "Id", user.Contactid);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["Addressid"] = new SelectList(_context.Addresses, "Id", "Id", user.Addressid);
            ViewData["Cardid"] = new SelectList(_context.Cards, "Id", "Cardnumber", user.Cardid);
            ViewData["Contactid"] = new SelectList(_context.Contacts, "Id", "Id", user.Contactid);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Contactid,Addressid,Cardid,Nationalid,Firstname,Lastname,Birthplace,Birthyear")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["Addressid"] = new SelectList(_context.Addresses, "Id", "Id", user.Addressid);
            ViewData["Cardid"] = new SelectList(_context.Cards, "Id", "Cardnumber", user.Cardid);
            ViewData["Contactid"] = new SelectList(_context.Contacts, "Id", "Id", user.Contactid);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Card)
                .Include(u => u.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(decimal id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
