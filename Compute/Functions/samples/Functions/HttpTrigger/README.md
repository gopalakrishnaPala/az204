# HTTP Trigger
An HTTP trigger is a trigger that executes a function when it receives an HTTP request.

## HTTP trigger functions have following capabilities and customizations
- Provide authorized access by supplying keys.
- Restrict which HTTP words are supported.
- Return back data to caller.
- Receive data through query parameters or request body.
- Support URL route templates to modify the function URL.

## HTTP trigger Authorization levels
- Function
- Anonymous
- Admin

**Function** and **Admin** level are keys based. Must supply a key for authentication. The difference between 2 keys are scope (Host or Function).

- If set to **Function** - can use both **Host** or **Function** keys.
- If set to **Admin**- can use only **Host** keys.

## Code
```csharp
public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route=null)] HttpRequest req,
    ILogger log
)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
    return new OkObjectResult("Welcome to Azure Functions");
}
```
