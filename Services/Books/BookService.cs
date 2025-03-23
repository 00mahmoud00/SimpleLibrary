using SimpleLibrary.Models;
using SimpleLibrary.Services.Authors;

namespace SimpleLibrary.Services.Books;

public class BookService : IBookService
{
    private readonly IAuthorService _authorService;
    
    private List<Book> _books = new();

    public BookService(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public void Add(Book book)
    {
        book.Id = _books.Count + 1;
        var author = _authorService.GetAll().FirstOrDefault(a => a.Id == book.AuthorId);
        book.Author = author;
        _books.Add(book);
    }

    public void Update(Book book)
    {
        throw new NotImplementedException();
    }

    public List<Book> GetAll()
    {
        return _books;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}