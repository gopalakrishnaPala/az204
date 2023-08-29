## Publish Messages to Service Bus - .NET Client

- Install Nuget Package Packages
    ```
    Azure.Messaging.ServiceBus
    ```

- Go to Service Bus namespace -*Shared access policies* and Create a new Policy

- Sending message to Service Bus Queue
```csharp
    var message = new ServiceBusMessage(data);
    var serviceBusClient = new ServiceBusClient(connectionString);
    var serviceBusSender = serviceBusClient.CreateSender(queueName);
    await serviceBusSender.SendMessageAsync(message);
```

    -   Setting the content type to message
    ```csharp
        message.ContentType = "application/json";
    ```