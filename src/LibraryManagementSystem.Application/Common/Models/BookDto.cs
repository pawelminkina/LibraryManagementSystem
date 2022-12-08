namespace LibraryManagementSystem.Application.Common.Models;
public record BookDto
{
    public string? Id { get; set; }
    public string? Content { get; set; }
    public string? Title { get; set; }
}
