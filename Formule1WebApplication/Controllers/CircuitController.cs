using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formule1WebApplication.Controllers;
public class CircuitController : Controller
{
    private readonly Formule1DbContext _db;

    public CircuitController(Formule1DbContext db)
    {
        _db = db;
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
    
    [Route("circuits/details/{id:int}")]
    public async Task<IActionResult> Details(int? id)
    {
        return View(await _db.Circuits
            .Include(c => c.Country)
            .Where(c => c.ID == id)
            .FirstAsync());
    }
}