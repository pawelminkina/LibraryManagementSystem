namespace LibraryManagementSystem.Domain.Entities;
public record Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
