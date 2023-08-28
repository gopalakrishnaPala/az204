

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
az account list                     # To get the subscription details
```

# Set the Parameters for creating Azure Function App
```cmd
resourceGroupName='gp-az204'        # Resource Group Name 
storageName='gpdemostorage'         # Storage Account Name
location='southindia'               # Resource Location
storageSku='Standard_LRS'           # Storage Sku
```

### Create Resource Group
```cmd
az group create --name $resourceGroupName --location $location
```

### Create a storage account
```cmd
az storage account create --name $storageName --resource-group $resourceGroupName --location $location --sku $storageSku
```

### Verify the created Function App
```cmd
az storage account list                     # Get all function apps
az storage account list | jq -r '.[].name'  # Get only the function app names
```

### Delete the resouce group
```cmd
az group delete --name $resourceGroupName
```