

### Login to Azure Acount
```
az login
```


### Set the Subscription
```
subscriptionid="<subscription id>"  # Azure Subscription Id
az account set -s $subscriptionid   # Set the Subscription
```

```
az account list # To get the subscription details
```

# Set the Parameters for creating Azure Function App
```
resourceGroupName='rg-gp-az204' 
functionAppName='func-gp-az204'
functionsVersion='4'
storageName='stgpaz204'
location='southindia'
storageSku='Standard_LRS'
runtime='dotnet-isolated'
runtimeVersion='6'
```

 *<u>Help</u>*To list all the azure locations use
    ```
    az account list-locations
    ```

#### We can use jq library to query json in terminal
```
 brew install jq
 az account list-locations | jq -r '.[].name'
 ```

 ### Create Resource Group
```
az group create --name $resourceGroupName --location $location
```

### Create a storage account required for Azure Function App
```
az storage account create --name $storageName --resource-group $resourceGroupName --location $location --sku $storageSku
```

### Create Azure Function App
```
az functionapp create --name $functionAppName --resource-group $resourceGroupName --consumption-plan-location $location --storage-account $storageName --functions-version $functionsVersion --runtime $runtime --runtime-version $runtimeVersion
```

 *<u>Help</u>*To list all the azure locations use
    ```
    az functionapp list-runtimes
    ```

### Verify the created Function App
```
az functionapp list                     # Get all function apps
az functionapp list | jq -r '.[].name'  # Get only the function app names
```

### Delete the resouce group
```
az group delete --name $resourceGroupName
```