namespace LibraryManagementSystem.Domain.Entities;

public class Page
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public int Number { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
}