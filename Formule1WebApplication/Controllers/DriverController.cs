using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formule1WebApplication.Controllers;

public class DriverController : Controller
{
    private readonly Formule1DbContext _db;

    public DriverController(Formule1DbContext db)
    {
        _db = db;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _db.Drivers.ToListAsync());
    }

    [Route("coureur/details/{id:int}")]
    public async Task<IActionResult> Details(int id)
    {
        return View(await _db.Drivers.FirstAsync(d => d.ID == id));
    }
}