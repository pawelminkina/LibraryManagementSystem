namespace LibraryManagementSystem.Infrastructure.POCO;

public record BlobOptions
{
    public string ConnectionString { get; set; }
    public string DefaultContainer { get; set; }
}