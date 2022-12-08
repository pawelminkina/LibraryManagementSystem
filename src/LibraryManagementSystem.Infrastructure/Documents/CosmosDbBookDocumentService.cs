using System.ComponentModel;
using System.Diagnostics;
using LibraryManagementSystem.Application.Services.Documents;
using LibraryManagementSystem.Infrastructure.Documents.Models;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Container = Microsoft.Azure.Cosmos.Container;

namespace LibraryManagementSystem.Infrastructure.Documents;

public class CosmosDbBookDocumentService : IBookDocumentService
{
    private readonly IOptions<CosmosOptions> _config;
    private readonly ILogger<CosmosDbBookDocumentService> _logger;

    public CosmosDbBookDocumentService(IOptions<CosmosOptions> config, ILogger<CosmosDbBookDocumentService> logger)
    {
        _config = config;
        _logger = logger;
    }
    public async Task UploadDocumentAsStream(Stream document, string name)
    {
        var model = Deserialize<UsedModel>(document);
        
        var timer = Stopwatch.StartNew();

        var client = new CosmosClient(_config.Value.ConnectionString);
        var container = client.GetContainer(_config.Value.DbName, _config.Value.CollectionName);

        model.Id = name;
        model.PartitionKey = string.Empty;
        await container.CreateItemAsync(model, new PartitionKey(string.Empty));

        timer.Stop();
        
        _logger.LogInformation($"Time to create item with creating connection: {timer.ElapsedMilliseconds}");
    }

    public static T Deserialize<T>(Stream s)
    {
        using var reader = new StreamReader(s);
        using var jsonReader = new JsonTextReader(reader);
        var ser = new JsonSerializer();
        return ser.Deserialize<T>(jsonReader);
    }
}