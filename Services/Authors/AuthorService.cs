using SimpleLibrary.Models;

namespace SimpleLibrary.Services.Authors;

public class AuthorService : IAuthorService
{
    private List<Models.Author> _authors = new();

    public void Add(Models.Author author)
    {
        _authors.Add(author);
    }

    public void Update(Author author)
    {
        var authorToUpdate = _authors.First(a => a.Id == author.Id);
        authorToUpdate.Name = author.Name;
        authorToUpdate.Email = author.Email;
    }

    public List<Models.Author> GetAll()
    {
        return _authors;
    }

    public void Delete(int id)
    {
        var authorToDelete = _authors.First(a => a.Id == id);
        _authors.Remove(authorToDelete);
    }
}