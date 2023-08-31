# Azure Container Instances

- Containers offer a Standard and repeatable way to package, deploy, and manage cloud applications.
- Azure Container Instances let you run containers in Azure

## Run Azure Container Instances
- Why use Container Instances
    - Fast Startup
    - Per second billing
    - Hypervisor-level security
    - Custom sizes
    - Persistent storage
    - Linux and Windows

- Declare Variable  
    ```
    resourceGroup = 'rg-gp-az204'
    location = 'southindia'
    dnsnamelabel='aci-gp-az204'
    containerName='gp-az204'
    ```

- Create resource group
    ```
    az group create --name $resourceGroup --location $location
    ```

- Start Container Instance
    ```
    az container create \
    --resource-group $resourceGroup \
    --name $containerName \
    --image mcr.microsoft.com/azuredocs/aci-helloworld \
    --ports 80 \
    --dns-name-label $dnsnamelabel \
    --location $location
    ```

- Check status
    ```
    az container show --resource-group $resourceGroup --name $containerName --query "{FQDN:ipAddress.fqdn,ProvisioningState:provisioningState}" --output table
    ```
-- From a browser, go to your container's FQDN to see it running. 

## Control restart behavior
- Container restart Policies
    | Always | containers in container group are always restarted. For long running like webapp. Default applied |
    | Never  | Containers in container group are never restarted |
    | OnFailure | are restarted only when the process executed in the container fails (when it terminates with non-zero exit code) |    

- Run a container to completion
    ```
    az container create \
    --resource-group $resourceGroup
    --name $containerName
    --image mcr.microsoft.com/azuredocs/aci-wordcount:latest \
    --restart-policy OnFailure \
    --location $location
    ```
- Check containers status
    ```
    az container show \
    --resource-group $resourceGroup
    --name $containerName
    --query "container[0].instanceView.currentState.state"
    ```
- View container logs
    ```
    az container logs --resource-group $resourceGroup --name $containerName 
    ```

## Set Environment variables
- allows you to dynamically configure the application or the script container runs

- Create Azure Cosmos DB and use environment variables to pass connection string to an Azure container instance
    - set cosmos db name
        ```
        COSMOS_DB_NAME=aci-gp-cosmos-db-$RANDOM
        ```
    - Create Azure Cosmos db
        ```
        COSMOS_DB_ENDPOINT=$(az cosmosdb create \
        --resource-group $resourceGroup \
        --name $COSMOS_DB_NAME \
        --query documentEndpoint \
        --output tsv)
        ```

    - Get Azure Cosmos DB Connection key
        ```
        COSMOS_DB_MASTERKEY=$(az cosmosdb keys --resource-group $resourceGroup --name $COSMOS_DB_NAME --query PrimaryMasterKey --output tsv)
        ```
