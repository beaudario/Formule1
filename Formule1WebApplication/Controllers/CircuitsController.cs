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
    public class CircuitsController : Controller
    {
        private readonly Formule1DbContext _context;

        public CircuitsController(Formule1DbContext context)
        {
            _context = context;
        }

        // GET: Circuits
        public async Task<IActionResult> Index()
        {
            return _context.Circuits != null ?
                        View(await _context.Circuits.Include(c => c.Country).ToListAsync()) :
                        Problem("Entity set 'Formule1DbContext.Circuits'  is null.");
        }

        public async Task<IActionResult> TopCoureur(int id)
        {
            var result = _context.Results.Include(x => x.Driver).Where(x => x.CircuitID == id).OrderBy(x => x.Driver.Results);

            return View();
        }

        // GET: Circuits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Circuits == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits.Include(c => c.Results).ThenInclude(x => x.Driver).ThenInclude(d => d.Results).Include(g => g.Results).
                                                  ThenInclude(g => g.Team).ThenInclude(g => g.Results)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (circuit == null)
            {
                return NotFound();
            }
            var winnersCoureur = circuit.Results.GroupBy(r => r.Driver);
            ViewBag.NumberOfWin = winnersCoureur.Count();
            ViewBag.NumberOfRaces = circuit.Results.Count();
            List<TopViewModel> topWinners = new List<TopViewModel>();
            foreach (var winner in winnersCoureur)
            {
                var topVM = new TopViewModel();
                topVM.Naam = winner.Key.Fullname;
                topVM.Overwinningen = winner.Key.Results.Where(r => r.CircuitID == id).Count();
                topWinners.Add(topVM);
            }
            ViewBag.WinnersC = topWinners.OrderByDescending(t => t.Overwinningen).Take(3).ToList();

            var winnersTeams = circuit.Results.GroupBy(r => r.Team);
            List<TopViewModel> topTeams = new List<TopViewModel>();
            foreach (var winner in winnersTeams)
            {
                var topVM = new TopViewModel();
                topVM.Naam = winner.Key.Name;
                topVM.Overwinningen = winner.Key.Results.Where(r => r.CircuitID == id).Count();
                topWinners.Add(topVM);
            }
            ViewBag.WinnersT = topWinners.OrderByDescending(t => t.Overwinningen).Take(3).ToList();



            return View(circuit);
        }

        // GET: Circuits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Circuits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Latitude,Longitude,Wiki")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(circuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(circuit);
        }

        // GET: Circuits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Circuits == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }
            return View(circuit);
        }

        // POST: Circuits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Latitude,Longitude,Wiki")] Circuit circuit)
        {
            if (id != circuit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitExists(circuit.ID))
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
            return View(circuit);
        }

        // GET: Circuits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Circuits == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // POST: Circuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Circuits == null)
            {
                return Problem("Entity set 'Formule1DbContext.Circuits'  is null.");
            }
            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit != null)
            {
                _context.Circuits.Remove(circuit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitExists(int id)
        {
            return (_context.Circuits?.Any(e => e.ID == id)).GetValueOrDefault();
        }


    }
}
