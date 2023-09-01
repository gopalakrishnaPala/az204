# Azure CLI

## Installation
>  🌟 [Install Azure CLI Locally](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) 🌟

> Run on Docker Container <br />
> `docker run -it mcr.microsoft.com/azure-cli`

## Commands syntax
🌟 ***Syntax pattern*** 🌟
> `command group + command subgroup + command + --parameters`


*Example*:
> `az storage account create --name myStorageAccount`
> | command | subgroup | command | parameters |
> | ------- | -------- | ------- | ---------- |
> | storage | account | create | name |

🌟 ***Command Groups*** 🌟
[Commands Reference] (https://learn.microsoft.com/en-us/cli/azure/reference-index?view=azure-cli-latest)

| az vm | Manage Virtual Machines |
| az functionapp | Manage Function apps |
| az acr | Manage Azure Container Registries |
| az container | Manage Azure container Instances |
| az containerapp | Manage Azure Container Apps |  
| az webapp | Manage Web Apps |
| az storage | Manage Storage Resources |
| az apim | Manage API Management Services |
| az servicebus | Manage Service bus |
| az eventhubs | Manage Event hubs |
| az eventgrid | Manage Event grids |
| az cosmosdb | Manage Cosmos db |


🌟 ***Common commands*** 🌟

| Command | Description | Example |
| ------- | ----------- | ------- |
| create  | create a resource | `az storage account create --name  myStorageAccount` |
| update  | update a resource | `az storage update create --sku Standard_LRS`
| list    | list resources | `az functionapp list` |

🌟 ***Common parameters*** 🌟
| Parameter | Description |
| --------- | ----------- |
| resource-group | Resource group associated with the resource |
| location | location of the resource |
| name | name of the resource |



## Login 
```
az login
```

## Manage subscriptions
- Get the current default subscription using show
    ```
    az account show
    ```

- change the active subscription using the subscription name
    ```
    az account set --subscription "My Demos"
    ```

- Change the active subscription using the subscription ID
    ```
    az account set --subscription "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
    ```

## Manage Resource Groups
- To see all locations
    ```
    az account list-locations
    ```

- Create a resource group
    ```
    az group create --name MyResourceGroup --location southindia
    ```

- 





