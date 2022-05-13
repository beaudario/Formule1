using Microsoft.AspNetCore.Mvc;

namespace Formule1WebApplication.Controllers;

public class DriverController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}