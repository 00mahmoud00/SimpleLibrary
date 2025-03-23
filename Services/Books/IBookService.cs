using SimpleLibrary.Models;

namespace SimpleLibrary.Services.Books;

public interface IBookService
{
    void Add(Book book);
    void Update(Book book);
    List<Book> GetAll();
    void Delete(int id);
}