using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BlobTrigger
{
    public class BlobExample
    {
        private readonly ILogger _logger;

        public BlobExample(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BlobExample>();
        }

        [Function("BlobExample")]
        public void Run([BlobTrigger("data/{name}", Connection = "StorageConnection")] string myBlob, string name)
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {myBlob}");
        }
    }
}
