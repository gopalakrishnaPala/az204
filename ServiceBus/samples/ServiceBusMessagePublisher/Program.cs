using System.Net;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;


var connectionString = "Endpoint=sb://sb-gp-az204.servicebus.windows.net/;SharedAccessKeyName=publisher;SharedAccessKey=8HR4oGq6sRPsvPYUcXSyfT/+6NVwL44jG+ASbFwiZ7Y=";
var queueName = "sbq-gp-az204";


var order = new Order(1, "O1", 10);
var orderJson = JsonConvert.SerializeObject(order);
await SendMessageToQueue(orderJson);

var batchMessages = new List<string>();

for(int i = 0; i < 10; i++)
{
    var o = new Order(i, $"O{i}", i * 10);
    batchMessages.Add(JsonConvert.SerializeObject(o));
}

await SendBatchMessagesAsync(batchMessages);
Console.ReadKey();

async Task SendMessageToQueue(string data)
{
    var message = new ServiceBusMessage(data);
    message.ContentType = "application/json";
    var sbClient = new ServiceBusClient(connectionString);
    var sbSender = sbClient.CreateSender(queueName);

    try
    {
        await sbSender.SendMessageAsync(message);
        Console.WriteLine($"Completed sending message to Service Bus Queue, message:[{data}]");
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


async Task SendBatchMessagesAsync(IEnumerable<string> data)
{
    var sbClient = new ServiceBusClient(connectionString);
    var sbSender = sbClient.CreateSender(queueName);
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
        Console.WriteLine($"Completed sending Batch of {data.Count()} messages to Service Bus Queue");
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