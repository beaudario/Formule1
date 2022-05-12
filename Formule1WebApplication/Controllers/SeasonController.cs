using Formule1Library.Data;
using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formule1WebApplication.Controllers;

public class SeasonController : Controller
{
    private readonly Formule1DbContext _db;

    public SeasonController(Formule1DbContext db)
    {
        _db = db;
    }

    [Route("Seizoen/{id:int}")]
    public async Task<IActionResult> Index(int id)
    {
        return View(await _db.Results
            .Where(r => r.Year == id)
            .ToListAsync());
    }
}