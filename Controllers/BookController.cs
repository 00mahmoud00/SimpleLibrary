using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleLibrary.Models;
using SimpleLibrary.Services.Authors;
using SimpleLibrary.Services.Books;

namespace SimpleLibrary.Controllers;

public class BookController : Controller
{
    private readonly BookService _bookService = new BookService();
    private readonly AuthorService _authorService = new AuthorService();

    public IActionResult Index()
    {
        var books = _bookService.GetAll();
        return View(books);
    }

    public IActionResult Create()
    {
        var authors = _authorService.GetAll();
        ViewBag.AuthorList = authors.Select(a => new SelectListItem()
        {
            Text = a.Name,
            Value = a.Id.ToString()
        });
        return View();
    }

    public IActionResult NewBook(Book book)
    {
        _bookService.Add(book);
        return RedirectToAction("Index");
    }
}