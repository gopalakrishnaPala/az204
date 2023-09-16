# Azure CLI

## Installation
![Microsoft Learn](https://img.shields.io/badge/Microsoft_Learn-258ffa?style=for-the-badge&logo=microsoft&logoColor=white)  <br />
[Install Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)   

![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)  <br />
***Run on Docker Container***

```docker
docker run -it mcr.microsoft.com/azure-cli
```

## Commands syntax
![Syntax Pattern](https://img.shields.io/badge/Syntax_pattern-blue?logo=pinboard) <br />
`[group]  [subgroup]  [command] [--parameters]`


![Example](https://img.shields.io/badge/Example-green?logo=pinboard)
```
az storage account create --name myStorageAccount
```

| command | subgroup | command | parameters |
| ------- | -------- | ------- | ---------- |
| storage | account | create | name |


### Command Groups

| Command | Description |
| ----- | ----------------------- |
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

![Syntax Pattern](https://img.shields.io/badge/Reference-blue?logo=pinboard) ![Microsoft Learn](https://img.shields.io/badge/Microsoft_Learn-258ffa?style=for-the-badge&logo=microsoft&logoColor=white)  <br />
[Commands Reference](https://learn.microsoft.com/en-us/cli/azure/reference-index?view=azure-cli-latest)

### Commands
| Command | Description | Example |
| ------- | ----------- | ------- |
| create  | create a resource | `az storage account create --name  myStorageAccount` |
| update  | update a resource | `az storage update create --sku Standard_LRS` |
| delete    | delete a resources | `az group delete --name myResourceGroup` |
| list    | list resources | `az functionapp list` |

### Parameters
| Parameter | Short hand | Description |
| --------- | ---------- | ---------- |
| --resource-group |  -g | Resource group associated with the resource |
| --location | -l |location of the resource |
| --name | -n | name of the resource |
| --output | -o | formate output |

### Command output format
use --output (--out or -o) parameter to format CLI output

| --output | Description |
| -------- | ----------- |
| json	| JSON string. This setting is the default |
| jsonc | Colorized JSON |
| yaml | YAML, a human-readable alternative to JSON |
| yamlc | Colorized YAML |
| table | ASCII table with keys as column headings |
| tsv | Tab-separated values, with no keys |
| none | No output other than errors and warnings |

![Syntax Pattern](https://img.shields.io/badge/Reference-blue?logo=pinboard) ![Microsoft Learn](https://img.shields.io/badge/Microsoft_Learn-258ffa?style=for-the-badge&logo=microsoft&logoColor=white)  <br />
[Output formats for Azure CLI commands](https://learn.microsoft.com/en-us/cli/azure/format-output-azure-cli)


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





