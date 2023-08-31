# Create Azure Function App using Azure CLI

## Set the Parameters for creating Azure Function App
```
resourceGroup='rg-gp-az204'
location='southindia'
functionApp='func-gp-az204'
storageAccount='stgpaz204'
```

> For getting the available azure locations and other account help commands
> 🌟 [Azure Account Help Commands]() 🌟 

## Create Resource Group
```azurecli
az group create --name $resourceGroup --location $location
```
    
## Create a storage account associated with Function Appp
```azurecli
az storage account create --name $storageAccount --resource-group $resourceGroup --location $location --sku Standard_LRS
```

## Create Azure Function App
```azurecli
az functionapp create --name $functionApp --resource-group $resourceGroup --consumption-plan-location $location --storage-account $storageAccount --functions-version 4 --runtime dotnet-isolated --runtime-version 6
```

## Verify the created Function App
```azurecli
az functionapp list --output table
```

## Delete the resouce group
```azurecli
az group delete --name $resourceGroup
```
