
# Create Azure Storage Account


> More Details on Azure CLI refer🌟 [Azure CLI Documentation](../AzureCLI.md) 🌟 

# Set the Parameters for creating Azure Function App
```cmd
resourceGroup='rg-gp-az204'
storage'stggpaz204'
location='southindia'
```

### Create Resource Group
```cmd
az group create --name $resourceGroup --location $location
```

### Create a storage account
```cmd
az storage account create --name $storageAccount --resource-group $resourceGroup --location $location --sku Standard_LRS
```

### Verify the created Function App
```cmd
az storage account list  
```

### Delete the resouce group
```cmd
az group delete --name $resourceGroup
```