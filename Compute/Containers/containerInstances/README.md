# Azure Container Instances
## References
[Pluralsight Course](https://app.pluralsight.com/library/courses/azure-container-instances-getting-started/table-of-contents)

## Introduction
- The fastest and easiest way to get containers running in Azure
- Don't need to manage the underlying infrastructure.
- Can also get their own Public IP and DNS name.
- Can also persist data via the use of Azure File shares.

### Docker
- Package your application into a "Docker image"
- Run it on a Docker host as a "container"
- Works the same wherever it is deployed
- Easliy run third party containers from a registry
- Build distributed applications with multiple containers

### Hosting Containers in Azure
- Docker VM (Virtual Machine)
- Orchestrator (e.g. Kubernetes) - Azure Kubernetes Service
- Azure App Service
- Azure Batch
- Azure Service Fabric

### Why Azure Container Instances?
- Quick experiments
- Serverless containers
    - Azure manages the VMs
    - Just specify the container
    - Per-second billing model

### ACI Pricing Model
- Meters
    - Container group duration
    - Windows software duration

***Note:*** `Azure Container instances will save money for occasional workloads.. but cost more for continuoulsy running workloads`.

### When to user Azure Container Instances?
- Occasionally Running
    - Continuous integration
    - Quick experiments
    - Load testing
    - Batch jobs
    - Handle spikes in load

### ACI Features
- Easy to Create
    - Azure CLI
    - PowerShell
    - C# fluent SDK
    - ARM templates
- Networking
    - Public IP address
    - Domain name prefix
        - aci-demo.eastus.azurecontainer.io
- Expose ports
- Container types
    - Windows
    - Linux
- Restart policy
- Mount Volumes
    - Azure File Shares
    - Secrets
    - Git repositories
- Custom command line
- Set environment variables
- view logs
- Container Groups
    - A *container group* ofter hosts a single container, They can also host multiple containers similar to a Kubernetes *pod*

### ACI and Orchestrators
- Orchestrator responsibilities
    - Scheduling
    - Health monitoring
    - Failover
    - Scaling
    - Networking
    - Service discovery

***Note:*** `ACI is not intended to be an orchestrator`
- ACI Connector for Kubernetes - Virtual Kubelet


## Running Containerized Tasks
### Creating Azure Container Instances using Azure CLI
#### Set up the parameters
```
resourceGroup='rg-gp-az204'
location='southindia'
containerGroup = 'gp-az204-sample01'
```

#### Create resource group
```
az group create --name $resourceGroup --location $location
```

#### Create container group
```
az container create -g $resourceGroup -n $containerGroup --image ghost --ports 2368 --ip-address public --dns-name-label gpaz204sample01
```

| Parameter | Description |
| --------- | ----------- |
| --name    | Container group name |
| -g or --resource-group | Resource group |
| --image | e.g. docker hub image |
| --ip-address | request a public IP |
| --dns-name-label | friendly dns name |
| --ports | open specified port(s) |
| --os-type| default is linux |
| --memory | Memory |
| --cup | CPU F|
| --restart-policy | OnFailure, Always, Never |
| --registry-username | Registry user name |
| --registry-password | Registry password |

#### View the status of the container group
```
az container show -g $resourceGroup -n $containerGroup
```

#### View the logs
```
az container logs -n $containerGroup -g $resourceGroup
```

#### Create using Powershell
- `New-AzureRmContainerGroup`
- `Get-AzureRmContainerGroup`
- `Get-AzureRmContainerInstanceLog`

### Create a windows container
`--os-type windows`

### Creating Azure Container Registry
[Refer](../ContainerRegistry)

## Mounting volumes
- **Persisting data with Container**
- *Avoid* saving data directly into containers. Instead persist data to a *volumne*.
- Containers are disposable; volumes can be re-attached.
- Mount
    - Azure File Share Volumes
        - Use Azure Storage Explorer to view the data
    - Git Repositories
        - e.g. Implementing CI build
    - Secret Volumes
        - Secure storage of secrets
    - Empty volumes
        - Share data between containers in a container group

### Mounting Azure File Share Volumes
- Azure File Shares are created in a storage account
- Volume mounting CLI arguments
    | parameter | description |
    | --------- | ----------- |
    | --azure-file-volume-account-name | name of the storage account |
    | --azure-file-volume-account-key | secret key of the storage account |
    | --azure-file-volume-name | name of the file share |
    | --azure-file-volume-mount-path | where to mount in container |

- Limitions
    - Whole share must be mounted
    - Read-only not supported
    - Can't create multiple volumes with Azure CLI
        - User ARM templates instead
    - Not yet supported on Windows

### Mounting Git Repository Volumes

### Mounting Secret Volumes
- Stored in a RAM-backed file system
- --secret-mount-path "/mnt/secrets"

### Mounting Empty Volumes
- Can be shared between containers in a container group
- Enables the "sidecar" pattern
- Lifetime is tied to the container group

## Deploying Container Groups
- Can host one or more containers
- Scheduled on the same host machine
- Share common resources
    - Volumes
    - Networking
- Share a common lifecycle
- Can communicate on localhost

### When not to use Container Groups
- Don't put all microservices into one container group
- Don't use a single container group for scale out

### Implementing the "Sidecar" Pattern
Reference free e-book: 
[Designing Distributed systems by Brendan Burns](http://bit.ly/aci-sidecar)

### Defining an ARM template

### Managing Container Groups
```
az container logs -g $resourceGroup -n $containerGroup --container-name "back-end"
```

```
az container exec -g $resourceGroup -n $containerGroup --container-name "back-end" --exec-command "/bin/bash"
```

### Integrating with OtherAzure Services
- Azure Functions
    - Workflows (Durable Functions)
- Azure Logic Apps
    - Azure Container Instances Connector
- Azure Kubernetes Service (AKS)
    - ACI Kubernetes Connector (Virtual Kubelet)