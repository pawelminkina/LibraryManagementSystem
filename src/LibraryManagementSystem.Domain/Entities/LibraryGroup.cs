namespace LibraryManagementSystem.Domain.Entities;

public class LibraryGroup
{
    public LibraryGroup()
    {
        Libraries = new List<Library>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Library> Libraries { get; set; }
}