using System.Diagnostics;
using Azure.Storage.Blobs;
using LibraryManagementSystem.Application.Services.Files;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.Infrastructure.Files;

public class BlobStorageFileService : IFileService
{
    private readonly ILogger<BlobStorageFileService> _logger;
    private readonly BlobOptions _options;

    public BlobStorageFileService(IOptions<BlobOptions> options, ILogger<BlobStorageFileService> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    public async Task UploadFile(Stream content, string filename)
    {
        var blobClient = new BlobClient(_options.ConnectionString, _options.DefaultContainer, filename);

        var timer = Stopwatch.StartNew();

        var result = await blobClient.UploadAsync(content);
        
        var status = result.GetRawResponse().Status;
        
        timer.Stop();

        _logger.LogInformation($"Time to upload file: {timer.ElapsedMilliseconds} ms");
        
        CheckResponse(status);
    }

    private static void CheckResponse(int statusCode)
    {
        if (statusCode is 200 or 201 or 204)
            return;

        throw new InvalidOperationException("status code 500");
    }
}