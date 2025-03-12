namespace SimpleLibrary.Services.Authors;

public interface IAuthorService
{
    void Add(Models.Author author);
    void Update(Models.Author author);
    List<Models.Author> GetAll();
    void Delete(int id);
}