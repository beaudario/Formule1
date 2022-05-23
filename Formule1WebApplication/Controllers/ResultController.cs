using System.Diagnostics;
using Formule1Library;
using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;
using Formule1WebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Formule1WebApplication.Controllers;

public class ResultController : Controller
{
    private readonly Formule1DbContext _db;

    public ResultController(Formule1DbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _db.Results.ToListAsync());
    }

    [Route("Result/Details/{id:int}")]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        if (id > DateTime.Now.Year || id < 1950)
        {
            return NotFound();
        }

        return View(await _db.Results
            .Where(r => r.Season == id)
            .Include(r => r.Driver)
                .ThenInclude(r => r.Country)
            .Include(r => r.Team)
                .ThenInclude(r => r.Country)
            .Include(r => r.Circuit)
                .ThenInclude(r => r.Country)
            .Include(r => r.Grandprix)
            .ToListAsync()
        );
    }

    public async Task<IActionResult> Create()
    {
        var drivers =  await _db.Drivers.ToListAsync();
        var teams = await _db.Teams.ToListAsync();
        var circuits = await _db.Circuits.ToListAsync();
        var grandprixes = await _db.Grandprixes.ToListAsync();

        ViewBag.CreateDrivers = new SelectList(drivers, "ID", "Fullname");
        ViewBag.CreateTeams = new SelectList(teams, "ID", "Name");
        ViewBag.CreateCircuits = new SelectList(circuits, "ID", "Name");
        ViewBag.CreateGrandprixes = new SelectList(grandprixes, "ID", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Result result)
    {
        if (!ModelState.IsValid) return View(result);

        await _db.AddAsync(result);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = await _db.Results
            .Include(r => r.Driver)
                .ThenInclude(r => r.Country)
            .Include(r => r.Team)
                .ThenInclude(r => r.Country)
            .Include(r => r.Circuit)
                .ThenInclude(r => r.Country)
            .Include(r => r.Grandprix)
            .FirstOrDefaultAsync(r => r.ID == id);

        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = await _db.Results.FirstOrDefaultAsync(r => r.ID == id);

        if (result == null)
        {
            return NotFound();
        }

        _db.Results.Remove(result);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Result/Update/{id:int}")]
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = await _db.Results.FirstOrDefaultAsync(r => r.ID == id);

        if (result == null)
        {
            return NotFound();
        }
        
        var drivers =  await _db.Drivers.ToListAsync();
        var teams = await _db.Teams.ToListAsync();
        var circuits = await _db.Circuits.ToListAsync();
        var grandprixes = await _db.Grandprixes.ToListAsync();

        ViewBag.UpdateDrivers = new SelectList(drivers, "ID", "Fullname");
        ViewBag.UpdateTeams = new SelectList(teams, "ID", "Name");
        ViewBag.UpdateCircuits = new SelectList(circuits, "ID", "Name");
        ViewBag.UpdateGrandprixes = new SelectList(grandprixes, "ID", "Name");
        
        return View(result);
    }

    public async Task<IActionResult> UpdateConfirmed(int? id, Result updatedResult)
    {
        if (id == null)
        {
            return NotFound();
        }

        var oldResult = await _db.Results.FirstOrDefaultAsync(r => r.ID == id);

        if (oldResult == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            oldResult.Season = updatedResult.Season;
            oldResult.Racenumber = updatedResult.Racenumber;
            oldResult.Rounds = updatedResult.Rounds;
            oldResult.Date = updatedResult.Date;
            oldResult.Time = updatedResult.Time;
            oldResult.CircuitID = updatedResult.CircuitID;
            oldResult.DriverID = updatedResult.DriverID;
            oldResult.GrandprixID = updatedResult.GrandprixID;
            oldResult.TeamID = updatedResult.TeamID;
            await _db.SaveChangesAsync();
        }
        
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}