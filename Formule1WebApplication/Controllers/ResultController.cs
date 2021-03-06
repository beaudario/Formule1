using System.Diagnostics;
using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;
using Formule1WebApplication.Models;
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
    
    [Route("details/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        return View(await _db.Results
            .Where(r => r.Season == id)
            .Include(r => r.Driver)
            .Include(r => r.Driver.Country)
            .Include(r => r.Team)
            .Include(r => r.Team.Country)
            .Include(r => r.Circuit)
            .Include(r => r.Circuit.Country)
            .Include(r => r.Grandprix)
            .ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}