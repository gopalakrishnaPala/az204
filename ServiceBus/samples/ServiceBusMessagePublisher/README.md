## Publish Messages to Service Bus - .NET Client
- Create Service Bus Namespace, Queue, Topics using [Azure CLI](../../1_CreateAzureServiceBusCLI.md)


- Install Service Bus messaging  Nuget Package
    ```
    Azure.Messaging.ServiceBus
    ```

- Get the Service Bus namespace from Azure Portal 
    - Navigate to Service Bus namespace
    - Go to *Shared access policies* menu item
    - Create a new Policy
        ```
        az servicebus namespace authorization-rule create --resource-group $resourceGroup --namespace $namespace --name publisher --rights Send
        ```
    - Get the connection string
        ```
        az servicebus namespace authorization-rule keys list --resource-group $resourceGroup    --namespace $namespace --name publisher 
        ```

- Sending message to Service Bus Queue
    ```csharp
    var message = new ServiceBusMessage(data);
    var sbClient = new ServiceBusClient(connectionString);
    var sbSender = sbClient.CreateSender(queueName);
    await sbSender.SendMessageAsync(message);
    ```

- Setting the content type on the message
    ```csharp
    var message = new ServiceBusMessage(data);
    message.CotentType = "application/json";
    ```

-- Sending the Batch of Messages
    ```csharp
    var sbClient = new ServiceBusClient(connectionString);
    var sbSender = sbClient.CreateSender(queueName);
    using ServiceBusMessageBatch messageBatch = await sbSender.CreateMessageBatchAsync();
    var message = new ServiceBusMessage(item);
    message.ContentType = "application/json";
    messageBatch.TryAddMessage(message);
    await sbSender.SendMessagesAsync(messageBatch);
    ```