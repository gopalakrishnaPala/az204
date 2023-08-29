using System.Net;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;


var connectionString = "Endpoint=sb://sb-gp-az204.servicebus.windows.net/;SharedAccessKeyName=publisher;SharedAccessKey=8HR4oGq6sRPsvPYUcXSyfT/+6NVwL44jG+ASbFwiZ7Y=";

// Publish Messages to Queue and Topics
await SendMessagesToQueue();
//await SendMessagesToTopic();

// Receive Messages from Queue and Topics
//await ReceiveMessageFromQueue();
Console.ReadKey();


async Task SendMessagesToQueue()
{
    var queueName = "sbq-gp-az204";
    await SendMessageToQueue(GetMessage(), queueName);
    await SendBatchMessagesAsync(GetMessages(), queueName);
}

async Task SendMessagesToTopic()
{
    var topicName = "sbt-gp-az204";
    await SendMessageToQueue(GetMessage(), topicName);
    await SendBatchMessagesAsync(GetMessages(), topicName);
}

string GetMessage()
{
    var order = new Order(1, "O1", 10);
    var message = JsonConvert.SerializeObject(order);
    return message;
}

IEnumerable<string> GetMessages()
{
    var batchMessages = new List<string>();
    for (int i = 0; i < 10; i++)
    {
        var o = new Order(i, $"O{i}", i * 10);
        batchMessages.Add(JsonConvert.SerializeObject(o));
    }
    return batchMessages;
}

async Task PollForMessageFromQueue()
{
    var queueName = "sbq-gp-az204";
    var sbClient = new ServiceBusClient(connectionString);
    var sbReceiverOptions = new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock, };
    var queueReceiver = sbClient.CreateReceiver(queueName, sbReceiverOptions);
    var messages = queueReceiver.ReceiveMessagesAsync();

    await foreach(var message in messages)
    {
        Console.WriteLine(message.Body);
    }
}

async Task ReceiveMessageFromQueue()
{
    var queueName = "sbq-gp-az204";
    var sbClient = new ServiceBusClient(connectionString);
    var sbReceiverOptions = new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock, };
    var queueReceiver = sbClient.CreateReceiver(queueName, sbReceiverOptions);
    var messages = await queueReceiver.ReceiveMessagesAsync(10);

    foreach (var message in messages)
    {
        Console.WriteLine(message.Body);
    }
}

async Task SendMessageToQueue(string data, string queueOrTopic)
{
    var message = new ServiceBusMessage(data);
    message.ContentType = "application/json";
    var sbClient = new ServiceBusClient(connectionString);
    var sbSender = sbClient.CreateSender(queueOrTopic);

    try
    {
        await sbSender.SendMessageAsync(message);
        Console.WriteLine($"Completed sending message to Service Bus Queue/Topic: [{queueOrTopic}], message:[{data}]");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    finally
    {
        await sbClient.DisposeAsync();
        await sbSender.DisposeAsync();
    }
}


async Task SendBatchMessagesAsync(IEnumerable<string> data, string queueOrTopic)
{
    var sbClient = new ServiceBusClient(connectionString);
    var sbSender = sbClient.CreateSender(queueOrTopic);
    using ServiceBusMessageBatch messageBatch = await sbSender.CreateMessageBatchAsync();

    try
    {
        foreach (var item in data)
        {
            var message = new ServiceBusMessage(item);
            message.ContentType = "application/json";
            messageBatch.TryAddMessage(message);
        }
        await sbSender.SendMessagesAsync(messageBatch);
        Console.WriteLine($"Completed sending Batch of {data.Count()} messages to Service Bus Queue/Topic: [{queueOrTopic}]");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    finally
    {
        await sbClient.DisposeAsync();
        await sbSender.DisposeAsync();
    }
}