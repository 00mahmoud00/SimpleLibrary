using Microsoft.AspNetCore.Mvc;
using SimpleLibrary.Models;
using SimpleLibrary.Services.Authors;

namespace SimpleLibrary.Controllers;

public class AuthorController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }


    public IActionResult Index()
    {
        var authors = _authorService.GetAll();
        return View(authors);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult NewAuthor(Author author)
    {
        _authorService.Add(author);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var author = _authorService.GetAll().FirstOrDefault(a => a.Id == id);
        return View(author);
    }
}