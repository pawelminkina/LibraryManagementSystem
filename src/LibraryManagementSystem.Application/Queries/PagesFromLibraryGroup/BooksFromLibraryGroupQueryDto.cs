namespace LibraryManagementSystem.Application.Queries.PagesFromLibraryGroup;

public record BooksFromLibraryGroupQueryDto
{
    public string LibraryGroupName { get; set; }
    public IEnumerable<LibraryWithBooks> LibrariesWithBooks { get; set; }
}

public record LibraryWithBooks
{
    public string LibraryName { get; set; }
    public IEnumerable<string> BooksContent { get; set; }
}