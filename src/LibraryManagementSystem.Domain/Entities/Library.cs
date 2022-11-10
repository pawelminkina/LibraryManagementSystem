namespace LibraryManagementSystem.Domain.Entities;
public class Library
{
    public Library()
    {
        Books = new List<Book>();
    }
    public Guid Id { get; set; }
    public Guid LibraryGroupId { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }
    public LibraryGroup LibraryGroup { get; set; }
}
