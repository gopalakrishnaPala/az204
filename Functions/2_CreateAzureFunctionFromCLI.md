# Create Azure Function App using Azure CLI

## Set the Parameters for creating Azure Function App
```
RESOURCE_GROUP='rg-gp-az204'
LOCATION='southindia'
FUNCATION_APP='func-gp-az204'
STORAGE='stgpaz204'
```

## Create Resource Group
```azurecli
az group create --name $RESOURCE_GROUP --location $LOCATION
```
    
## Create a storage account associated with Function Appp
```azurecli
az storage account create --name $STORAGE --resource-group $RESOURCE_GROUP --location $LOCATION --sku Standard_LRS
```

## Create Azure Function App
```azurecli
az functionapp create --name $FUNCATION_APP --resource-group $RESOURCE_GROUP --consumption-plan-location $LOCATION --storage-account $STORAGE --functions-version 4 --runtime dotnet-isolated --runtime-version 6
```

## Verify the created Function App
```azurecli
az functionapp list --output table
```

## Delete the resouce group
```
az group delete --name $RESOURCE_GROUP
```
