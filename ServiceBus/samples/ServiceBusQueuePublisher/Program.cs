// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;


var connectionString = "Endpoint=sb://sb-gp-az204.servicebus.windows.net/;SharedAccessKeyName=publishmessage;SharedAccessKey=CCfOVLsgCJubP3H0UXY5Lu/iDL4KYW4iA+ASbIgDvuQ=";
var queueName = "sbq-gp-az204";
var serviceBusClient = new ServiceBusClient(connectionString);
var serviceBusSender = serviceBusClient.CreateSender(queueName);
var order = new Order(1, "O1", 10);
var orderJson = JsonConvert.SerializeObject(order);
var message = new ServiceBusMessage(orderJson);
await serviceBusSender.SendMessageAsync(message);

Console.ReadKey();
