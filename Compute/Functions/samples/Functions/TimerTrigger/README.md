# Timer Trigger
A trigger that executes a function at a consistent interval. 

```csharp
[FunctionName("TimerTrigger")]
public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo timer, ILogger log)
{
    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
}
```

### CRON expression
A CRON expression is a string that consists of six fields that represent a set of times.

The order of the six fields in Azure is: `{second} {minute} {hour} {day} {month} {day of the week}`

| Special Character | Meaning | Example |
| :---------------: | ------- | ------- |
| * | Selects every value in a field | "*" in the day of the week field means every day. |
| , | Separates items in a list | "1, 3" in the day of the week field means Mondays (day 1) and Wednesday (day 3) |
| - | Specifies range | "10-12" in the hour field means range that include 10, 11, and 12. |
| / | Specifies increment | "*/10" in the minutes fields means increment of every 10 minutes. |

Example:
```
0 */5 * * * *
```
- `*/5` contains 2 special characters,
    - `*` - select every value within the field, `/` - represents increment. When both combined together - it means every values 0-59, select fifth value - "every five minutes"