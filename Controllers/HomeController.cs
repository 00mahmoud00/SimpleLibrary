using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleLibrary.Models;

namespace SimpleLibrary.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var ip = HttpContext.Connection.RemoteIpAddress;
        return View(ip);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Blocked()
    {
        return View();
    }

    public IActionResult NotFound()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}