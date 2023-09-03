### Run the following command from PowerShell to determine your PowerShell version

```cmd
$PSVersionTable.PSVersion
```


### Determine if you have the AzureRM PowerShell module installed:

```cmd
Get-Module -Name AzureRM -ListAvailable
```


### Use the Install-Module cmdlet to install the Az PowerShell module:

```cmd
Install-Module -Name Az -Repository PSGallery -Force
```


### Use Update-Module to update to the latest version of the Az PowerShell module:
```cmd
Update-Module -Name Az -Force
```

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

