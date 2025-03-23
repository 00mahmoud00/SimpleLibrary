namespace SimpleLibrary.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desctiption { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}