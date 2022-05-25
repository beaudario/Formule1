using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Formule1Library;
using Formule1Library.Data;
using Formule1WebApplication.Models;

namespace Formule1WebApplication.Controllers
{
    public class DriversController : Controller
    {
        private readonly Formule1DbContext _context;

        public DriversController(Formule1DbContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var drivers = from d in _context.Drivers
                .Include(d => d.Country)
                .Include(t => t.Teams)
                .Include(r => r.Results)
                          select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                drivers = drivers.Where(d => d.Fullname.Contains(searchString));
                                       
            }
            switch (sortOrder)
            {
                case "name_desc":
                    drivers = drivers.OrderByDescending(d => d.Fullname);
                    break;
                default:
                    drivers = drivers.OrderBy(d => d.Fullname);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Driver>.CreateAsync(drivers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .Include(d => d.Country)
                .Include(t => t.Teams)
                .Include(r => r.Results)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewData["TeamsID"] = new SelectList(_context.Teams, "ID", "Name");
            ViewData["CountryID"] = new SelectList(_context.Countries, "ID", "Name");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fullname,Birthdate,WikiUrl,Gender,ImageUrl,Country")] Driver driver, string Country)
        {
            driver.Country = _context.Countries.Find(Country);
            if (ModelState.IsValid)
            {
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.Include(d => d.Country).FirstAsync(d => d.ID == id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["CountryID"] = new SelectList(_context.Countries.OrderBy(c => c.Name), "ID", "Name"
                , driver.Country == null ? "" : driver.Country.ID);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Fullname,Birthdate,WikiUrl,Gender,ImageUrl,Country")] Driver driver, string Country)
        {
            if (id != driver.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    driver.Country = _context.Countries.Find(Country);
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.ID))
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
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drivers == null)
            {
                return Problem("Entity set 'Formule1DbContext.Drivers'  is null.");
            }
            var driver = await _context.Drivers.FindAsync(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
          return (_context.Drivers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
