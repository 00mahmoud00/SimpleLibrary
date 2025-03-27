using Microsoft.AspNetCore.Mvc;

namespace SimpleLibrary.Controllers;

public class BannedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}