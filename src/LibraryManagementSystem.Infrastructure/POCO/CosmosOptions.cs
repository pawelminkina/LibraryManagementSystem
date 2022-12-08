namespace LibraryManagementSystem.Infrastructure.POCO;

public record CosmosOptions
{
    public string CollectionName { get; set; }
    public string DbName { get; set; }
    public string ConnectionString { get; set; }

}