# Azure Functions

## Learning References
> 🌟 [Implement Azure Functions](https://learn.microsoft.com/en-us/training/paths/implement-azure-functions/) 🌟 

> 🌟 [Implement Azure Functions](https://learn.microsoft.com/en-us/training/paths/implement-azure-functions/) 🌟 

## Introduction
- Azure Functions is a serverless, event-driven compute service that is fully scalable, resilient, reliable, and secure.
- Azure Functions support 
    - **Triggers** - ways to start execution of function
    - **Bindings** - ways to simplify coding for input and output

### Azure Functions Components
| Component | Description |
| --------- | ----------- |
| Function trigger | what causes a function to run. |
| Function bindings | way of declaratively connecting another resource to the function; Maybe connected as input bindings, output bindings, or both. |
| Function runtime | support many different runtimes such as .NET, Java, PowerShell and Python |
| API Management | APIM provides security and routing for your HTTP triggered function endpoints |
| Deployment slots | allow function app to run different instances. Slots are different environments exposed via a publicly available endpoint. way to swap new version into production |
| Function app configuration | Connection strings, environment variables, and other application settings. Function app settings values can be read in teh code as environment variables. |

### Azure Functions hosting options
- **Hosting Plans**
    - **Consumption Plan** - Scales automatically and you only pay for compute sources when functions are running. This is a default hosting plan.
    - **Premium Plan** - Automatically scales based on pre-warmed workers, which run applications with no delay after being idle.
    - **Dedicated (App Service) Dedicated Plan** - Run Functions within a App Service plan at regular App Service plan rates.

    - **Other Hosting Options**
        - **ASE** - App Service Environment is an App Service feature that provides fully isolated and dedicated environment.
        - **Kubernetes(Direct or Azure Arc)** - fully isolated and dedicated environment running on top of kubernetes platform.

- **Function App timeout duration** (in mins)
    | Plan | Default | Maximum |
    | ---- | ------- | ------- |
    | Consumption plan | 5 | 10 |
    | Premium plan | 302 | Unlimited |
    | Dedicated plan | 302 | Unlimited |

### When to use Azure Functions
Azure Functions uses an event-based architecture.
- **Reminders and notification** - trigger that can be instructed to run at certain intervals
- **Scheduled tasks** - time-based triggers.
- **Experimental APIs** - Ideal for prototyping or Start-ups.
- **Irregular but important business flows** - 
- **Queue based** 
- **Processing data in real-time**
- **Analyze IoT stream** - process data from IoT devices.
- **Process file uploads**
- **Serverless workflow**

### Scale Azure Functions
- In Consumption and Premium plans, Azure Functions scales CPU and memory resources by adding more instances of the Function host.
- Unit of scale for Azure Functions is the function app.

### Storage account requirements
- On any plan, a function app requires Azure Storage account, which supports Azure Blob, Queue, Files and Table storage.
- Rely's on storage for operations such as managing triggers and logging function executions.

### Azure Functions monitoring
- Built-in integration with Azure Application Insights to monitor functions.

## Compare with Other Azure Services
### Compare Azure Functions with Web Jobs
- Like Azure Functions, Azure WebJobs with the WebJobs SDK is a code-first integration service.
- Both are built on Top of Azure Service Plan.
- Azure Functions are built on the WebJobs SDK.
    |         | Functions | WbJobs with WebJobs SDK |
    | ------- | --------- | ----------------------- |
    | Serverless app model with automatic scaling | Yes | No |
    | Pay-per-use pricing | Yes | No |
    | Integration with Logic Apps | Yes | No |


### Compare Azure Functions with Logic Apps
- Both Azure Functions and Logic Apps are Azure services that enable serverless workloads.
- Azure Functions are serverless compute service.
- Azure Logic Apps are serverless workflow integration service.

## Develop Azure Functions
Function contains two important pieces
- Code
- function.json File  
    - For compiled languages, config file is generated automatically from annotations in code, For scripting languages, must provide the config file yourself.
    - Defines the function's trigger, bindings and other configuration settings.
    - Every function has one and only one trigger.

    ```json
    {
        "disabled": false,
        "bindings": [
            // .. bindings here
            {
                "type": "bindingType",
                "direction": "in",
                "name": "myParamName", // used for the bound data in the function.
                // .. more depending on binding
            }
        ]
    }
    ```
### Function app
- Provides an execution context in Azure in which functions run.
- It's the unit of deployment and management for functions.
- Contains one or more functions that are managed, deployed, and scaled together.

### Folder structure
- Code for all the functions in a specific function app is located in a root project that contains a host configuration file (host.json). 
- Host.json file contains runtime-specific configurations and is the root folder of the function app.
- C# Compiles folder structure
    [Detailed .NET C# Functions](./FunctionCsharpDetailed.md)

### Creating triggers and bindings
- Triggers
- Binding

### Trigger and binding definitions
- **C# class library** - decorating methods and parameters with C# attributes

### Binding direction
- For triggers, the direction in always `in`
- Input and output bindings us `in` and `out`
- Some bindings support a special direction `inout`

### Azure Functions trigger and binding example
```json
{
    "bindings": [
        {
            "type": "queueTrigger",
            "direction": "in",
            "name": "order",
            "queueName": "myqueue-items",
            "connection": "MY_STORAGE_ACCT_APP_SETTING"
        },
        {
            "type": "table",
            "direction": "out",
            "name": "$return",
            "tableName": "outTable",
            "connection": "MY_TABLE_STORAGE_ACCT_SETTING"
        }
    ]
}
```
- `name` property identifies the function parameter
- `$return` using the function return value

### Connect functions to Azure services
Default configuration provider uses environment variable that are set in Application Settings when running in the Azure Function Service, or from the local settings file when developing locally.

### Configure an identity-based connection
- When hosted in Azure Functions service, identity-based connections use a managed identity.

### Grant permission to the identity
- use RBAC to assign permission to function app identity

## Execute an Azure Function with triggers
## Determins the best trigger for your Azure function
| Type | Purpose |
| ---- | ------- |
| **Timer** | Execute at a set interval |
| **HTTP** | Execute when an HTTP request is received. |
| **Blob** | Execute when a file is uploaded in Azure Blog storage. |
| **Queue** | Execute when a message is added to an Azure Storage Queue |
| **Azure Cosmos DB**| Execute when a document changes in a collection. |
| **Event Hub** | Execute when a event hub receives a new event. |

For Triggers and Binding Refer [https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library?tabs=v4%2Ccmd#triggers-and-bindings](https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library?tabs=v4%2Ccmd#triggers-and-bindings)

## Timer Trigger
A trigger that executes a function at a consistent interval. To create a timer trigger, you need to supply two pieces of information.
- A Timestamp parameter name
- A Schedule

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
    - `*` - select every value within the field
    - `/` - represents increment.
    - When both combined together - it means every values 0-59, select fifth value - "every five minutes"

## Create a time trigger 
### Create a Azure Function App
- [Using Azure portal](https://learn.microsoft.com/en-us/training/modules/develop-test-deploy-azure-functions-with-visual-studio/5-exercise-publish-azure-functions)
- [Using Azure CLI](CreateAzureFunctionFromCLI.md)
- [Using Powershell](CreateAzureFunctionFromPowershell.md)

### Create a Azure Function locally
- [Develop Azure Functions using Visual Studio](https://learn.microsoft.com/en-us/training/modules/develop-test-deploy-azure-functions-with-visual-studio/3-exercise-develop-and-test-azure-functions-locally)












