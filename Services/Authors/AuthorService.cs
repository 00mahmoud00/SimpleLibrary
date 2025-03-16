using SimpleLibrary.Models;

namespace SimpleLibrary.Services.Authors;

public class AuthorService : IAuthorService
{
    private List<Author> _authors = new()
    {
        new Author
        {
            Id = 1,
            Name = "Author 1",
            Email = "author1@gmail.com"
        },
    };

    public void Add(Author author)
    {
        author.Id = _authors.Count + 1;
        _authors.Add(author);
    }

    public void Update(Author author)
    {
        var authorToUpdate = _authors.First(a => a.Id == author.Id);
        authorToUpdate.Name = author.Name;
        authorToUpdate.Email = author.Email;
    }

    public List<Author> GetAll()
    {
        return _authors;
    }

    public void Delete(int id)
    {
        var authorToDelete = _authors.First(a => a.Id == id);
        _authors.Remove(authorToDelete);
    }
}