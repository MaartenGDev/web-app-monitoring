using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMonitoring.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{
    private readonly BlobServiceClient _blobServiceClient;

    public NewsController(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
    [HttpGet("Latest")]
    public string Get()
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("news");
        var blobClient = containerClient.GetBlobClient("news.txt");

        var newsFile = blobClient.DownloadContent();
        var content = newsFile.Value.Content;

        return content.ToString();
    }
}