using Formule1Library.Data;
using Microsoft.AspNetCore.Mvc;

namespace Formule1WebApplication.Controllers;
public class CircuitController : Controller
{
    private readonly Formule1DbContext _db;

    public CircuitController(Formule1DbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("circuits/details/{id:int}")]
    public IActionResult Details(int id)
    {
        return View();
    }
}