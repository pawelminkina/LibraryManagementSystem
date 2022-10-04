namespace LibraryManagementSystem.Application.Common.Models;
public record BookDto
{
    public string? Id { get; set; }
    public string? LibraryId { get; set; }
    public string? Title { get; set; }
}
