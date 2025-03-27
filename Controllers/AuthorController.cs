using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SimpleLibrary.Models;
using SimpleLibrary.Services.Authors;

namespace SimpleLibrary.Controllers;

public class AuthorController : Controller
{
    private AuthorService _authorService = new AuthorService();

    public IActionResult Index()
    {
        var memoryAddres = Unsafe.As<AuthorService, string>(ref _authorService);
        Console.WriteLine(memoryAddres);
        var authors = _authorService.GetAll();
        return View(authors);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult NewAuthor(Author author)
    {
        Console.WriteLine(JsonSerializer.Serialize(author));
        _authorService.Add(author);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var author = _authorService.GetAll().FirstOrDefault(a => a.Id == id);
        return View(author);
    }
}