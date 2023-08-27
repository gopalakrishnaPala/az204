### Login to Azure Acount
```cmd
Connect-AzAccount
```

### Set the Subscription
```cmd
$Subscription="<subscription id>"
Select-AzSubscription -SubscriptionId "$Subscription"
```

#### To get all the subscriptions
```cmd
# Get-AzSubscription 
```

### Set the Parameters for creating Azure Function App
```cmd
$ResourceGroupName='gp-fnapp'       # Resource Group Name
$FunctionAppName='gpdemo2fn'        # Function App Name 
$FunctionsVersion='4'               # Function Version Name - Allowed value 2, 3, 4
$StorageName='gpdemo2fnstorage'     # Storage Account Name required by Function App
$Location='southindia'              # Resource Location
$StorageSku='Standard_LRS'          # Storage Sku
$RunTime='DotNet'                   # Function Run time
```

#### To list all the azure locations use
```cmd
#   Get-AzLocation
```

#### To filter locations from india
```cmd
#   Get-AzLocation | Where-Object {$_.DisplayName -contains "India"}
```

### Create Resource Group
```cmd
New-AzResourceGroup -Name $ResourceGroupName -Location $Location
```

### Create a storage account required for Azure Function App
```
New-AzStorageAccount -Name $StorageName -ResourceGroup $ResourceGroupName -Location $Location -SkuName $StorageSku
```

### Create Azure Function App
```cmd
New-AzFunctionApp -Name $FunctionAppname -StorageAccountName $StorageName -Location $Location -ResourceGroupName $ResourceGroupName -FunctionsVersion $FunctionsVersion -RunTime $RunTime
```

### Verify the created Function App
```cmd
Get-AzFunctionApp
```

### Delete the resouce group
```cmd
Remove-AzResourceGroup -Name $ResourceGroupName
```
