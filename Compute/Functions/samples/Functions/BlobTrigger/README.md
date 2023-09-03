# Blob Trigger
A blob trigger is a trigger that executes a function when a file is uploaded or updated in Azure Blob storage.

## Code
```csharp
FunctionName("BlobTrigger")
public void Run([BlobTrigger("samples-workitems/{name}", connection="StorageConnectionstring")]Stream Blob, string name, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
}
```

One setting that's important to understand is the Path. 
```
samples-workitems/{name}
```
- The first part, **samples-workitems**, represents the blob container that the trigger monitors.
- The second part, **{name}** means that every type of file will cause the trigger to invoke the function

***Note:** Want to execute a function, only when png images are uploaded.
```
samples-workitems/{name}.png
```

