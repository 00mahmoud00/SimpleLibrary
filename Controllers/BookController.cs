using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleLibrary.Models;
using SimpleLibrary.Services.Authors;
using SimpleLibrary.Services.Books;

namespace SimpleLibrary.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    public BookController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

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