using System.Diagnostics;
using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;
using Formule1WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace Formule1WebApplication.Controllers;

public class HomeController : Controller
{
    private readonly Formule1DbContext _db;

    public HomeController(Formule1DbContext db)
    {
        _db = db;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _db.Results.ToListAsync());
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