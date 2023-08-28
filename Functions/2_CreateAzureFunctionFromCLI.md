

### Login to Azure Acount
```cmd
az login
```


### Set the Subscription
```cmd
subscriptionid="<subscription id>"  # Azure Subscription Id
az account set -s $subscriptionid   # Set the Subscription
```

```cmd
az account list # To get the subscription details
```

# Set the Parameters for creating Azure Function App
```cmd
resourceGroupName='gp-az204'        # Resource Group Name 
functionAppName='gpdemo2fn'         # Function App Name
functionsVersion='4'                # Function Version Name - Allowed value 2, 3, 4 
storageName='gpdemo2fnstorage'      # Storage Account Name required by Function App
location='southindia'               # Resource Location
storageSku='Standard_LRS'           # Storage Sku
```

#### To list all the azure locations use
```cmd
az account list-locations
```

#### We can use jq library to query json in terminal
```cmd
 brew install jq
 az account list-locations | jq -r '.[].name' # query all azure location names
 ```

 ### Create Resource Group
```cmd
az group create --name $resourceGroupName --location $location
```

### Create a storage account required for Azure Function App
```cmd
az storage account create --name $storageName --resource-group $resourceGroupName --location $location --sku $storageSku
```

### Create Azure Function App
```cmd
az functionapp create --name $functionAppName --resource-group $resourceGroupName --consumption-plan-location $location --storage-account $storageName --functions-version $functionsVersion
```

### Verify the created Function App
```cmd
az functionapp list                     # Get all function apps
az functionapp list | jq -r '.[].name'  # Get only the function app names
```

### Delete the resouce group
```cmd
az group delete --name $resourceGroupName
```