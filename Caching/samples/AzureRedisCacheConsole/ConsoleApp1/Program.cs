// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;
using System.Text;

Console.WriteLine("Hello, World!");


var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
{
    var connection = ConnectionMultiplexer.Connect("<get connection string>");
    return connection;
});
IDatabase cache = lazyConnection.Value.GetDatabase();

var sb = new StringBuilder();

var pingResult = cache.Execute("PING");
sb.Append($"PING \t\t\t\t");
sb.Append($"{pingResult} {Environment.NewLine}");

var flushallResult = cache.Execute("FLUSHALL");
sb.Append($"FLUSHALL \t\t\t");
sb.Append($"{flushallResult} {Environment.NewLine}");

var key = "greeting";
var setResult = cache.StringSet(key, "Hello from Console");
sb.Append($"Set Key {key} \t\t");
sb.Append($"{setResult} {Environment.NewLine}");

var greeting = cache.StringGet(key);
sb.Append($"Get Key {key} \t\t");
sb.Append($"{greeting} {Environment.NewLine}");

key = "name";
setResult = cache.StringSet(key, "Gopalakrishna Pala", expiry: new TimeSpan(0, 0, 10));
sb.Append($"Set Key {key} \t\t\t");
sb.Append($"{setResult} {Environment.NewLine}");

var name = cache.StringGet(key);
sb.Append($"Get Key {key} \t\t\t");
sb.Append($"{name} {Environment.NewLine}");

sb.Append($"Sleeping for 10 seconds..{Environment.NewLine}");
await Task.Delay(10000);

name = cache.StringGet(key);
sb.Append($"Get Key {key} \t\t\t");
sb.Append($"{name} {Environment.NewLine}");

Console.WriteLine(sb.ToString());
Console.WriteLine("Press any key to exit");
Console.ReadKey();