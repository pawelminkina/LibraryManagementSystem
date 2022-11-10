namespace LibraryManagementSystem.Domain.Entities;
public class Book
{
    public Book()
    {
        Pages = new List<Page>();
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public ICollection<Page> Pages { get; set; }
    public Library Library { get; set; }
    public Guid LibraryId { get; set; }
}
