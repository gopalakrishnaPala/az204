# Azure Functions

> 🌟 [ Implement Azure Functions](https://learn.microsoft.com/en-us/training/paths/implement-azure-functions/) 🌟 

## Introduction
- Azure Functions is a serverless solution that allows write less code, maintain less infrastructure and save cost.
- Azure Functions support 
    - **triggers** - ways to start execution of function
    - **bindings** - ways to simplify coding for input and output

## Compare Azure Functions with Logic Apps
- Both Azure Functions and Logic Apps are Azure services that enable serverless workloads.
- Azure Functions are serverless compute service.
- Azure Logic Apps are serverless workflow integration service.

## Compare Azure Functions with Web Jobs
- Like Azure Functions, Azure WebJobs with the WebJobs SDK is a code-first integration service.
- Both are built on Top of Azure Service Plan.
- Azure Functions are built on the WebJobs SDK.
|         | Functions | WbJobs with WebJobs SDK |
| ------- | --------- | ----------------------- |
| Serverless app model with automatic scaling | Yes | No |
| Pay-per-use pricing | Yes | No |
| Integration with Logic Apps | Yes | No |

## Azure Functions hosting options
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

## Storage account requirements
- On any plan, a function app requires Azure Storage account, which supports Azure Blob, Queue, Files and Table storage.
- Rely's on storage for operations such as managing triggers and logging function executions.

## Scale Azure Functions
- In Consumption and Premium plans, Azure Functions scales CPU and memory resources by adding more instances of the Function host.
- Unit of scale for Azure Functions is the function app.

    ```mermaid
    graph LR;
        A[Square Rect] -- Link text --> B((Circle))
        A --> C(Round Rect)
        B --> D{Rhombus}
        C --> D
    ```





