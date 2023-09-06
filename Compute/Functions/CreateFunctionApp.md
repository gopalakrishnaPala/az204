# Create Azure Function in Portal

### Step 1: Login to Azure Portal

1. Go to [Azure Portal](https://portal.azure.com/).
2. Sign in with your Azure account.

### Step 2: Create an Azure Function App

1. Click "+ Create a resource" and search for "Function App."
2. Fill in the required information and create the Function App.

### Step 3: Create an HTTP-based Function in Azure Portal

1. Inside the Function App, click "+ Add" to create a new function.
2. Choose "In-portal" as the development environment.
3. Select "Webhook + API" as the scenario.
4. Choose "HTTP trigger" as the template.
5. Provide a name, authentication level, and click "Create."

### Step 4: Test the Azure Function

1. Modify the function code to suit your needs.
2. Test the function to ensure it's working correctly.


# Create Azure Function App using Azure CLI
> More Details on Azure CLI refer🌟 [Azure CLI Documentation](../../AzureCLI.md) 🌟 

### Step 1: Set the Parameters 
```azurecli
resourceGroup='rg-gp-az204'
location='southindia'
functionApp='func-gp-az204'
storageAccount='stgpaz204'
```

### Step 2: Create Resource Group
```azurecli
az group create --name $resourceGroup --location $location
```
    
### Step 3: Create a storage account required for Function App
```azurecli
az storage account create --name $storageAccount --resource-group $resourceGroup --location $location --sku Standard_LRS
```

### Step 4: Create Azure Function App
```azurecli
az functionapp create --name $functionApp --resource-group $resourceGroup --consumption-plan-location $location --storage-account $storageAccount --functions-version 4 --runtime dotnet-isolated --runtime-version 6
```

# Create Azure Function App using Powershell

### Step 1: Set the Parameters 
```cmd
$ResourceGroup='rg-gp-az204' 
$Location='southindia'
$FunctionApp='func-gp-az204'
$StorageAccount='stgpaz204'
```

### Step 2:  Create Resource Group
```cmd
New-AzResourceGroup -Name $ResourceGroup -Location $Location
```

### Step 3: Create a storage account required for Function App
```
New-AzStorageAccount -Name $StorageAccount -ResourceGroup $ResourceGroup -Location $Location -SkuName Standard_LRS
```

### Step 4: Create Azure Function App
```cmd
New-AzFunctionApp -Name $FunctionApp -StorageAccountName $StorageAccount -Location $Location -ResourceGroupName $ResourceGroup -FunctionsVersion 4 -RunTime DotNet -RunTimeVersion 6
```