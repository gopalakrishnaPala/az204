# Install the Azure Functions Core Tools

```cmd
brew tap azure/functions
brew install azure-functions-core-tools@4
```

# Create a local function project

1. Run the func init command, as follows, to create a functions project in a folder named HttpTrigger with the specified .net 6 runtime:
```cmd
func init HttpTrigger --worker-runtime dotnet-isolated --target-framework net6.0
```

2. Navigate into the project folder:
```cmd
cd HttpTrigger
```

3. Add a function to your project by using the following command
```cmd
func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"
```

## Available Triggers for C#
    1. QueueTrigger
    2. HttpTrigger
    3. BlobTrigger
    4. TimerTrigger
    5. KafkaTrigger
    6. KafkaOutput
    7. DurableFunctionsOrchestration
    8. SendGrid
    9. EventHubTrigger
    10. ServiceBusQueueTrigger
    11. ServiceBusTopicTrigger
    12. EventGridTrigger
    13. CosmosDBTrigg

# Run a function locally
1. Run your function by starting the local Azure Functions runtime host
```cmd
func start
```

# Deploy the function
1. Deploy the function 
```cmd
func azure functionapp publish <APP_NAME>
```

2. Listen to Log stream
```cmd
func azure functionapp logstream <APP_NAME>
```
