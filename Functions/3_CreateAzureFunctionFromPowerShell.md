# Step 1: Login to Azure Acount
<pre>
Connect-AzAccount
</pre>
<br />

# Step 2: Set the Subscription
<pre>
<span class='comment'>-- Get all subscriptions </span>
Get-AzSubscription 

<span class='comment'>-- Set the Subscription</span>
$Subscription="&lt;subscription id&gt;"
Select-AzSubscription -SubscriptionId "$Subscription"
</pre>
<br />

# Step 3: Set the Parameters for creating Azure Function App
<pre>
<span class='comment'>-- Resource Group Name </span>
$ResourceGroupName='gp-fnapp'

<span class='comment'>-- Function App Name </span>
$FunctionAppName='gpdemo2fn'

<span class='comment'>-- Function Version Name - Allowed value 2, 3, 5 </span>
$FunctionsVersion='4'

<span class='comment'>-- Storage Account Name required by Function App </span>
$StorageName='gpdemo2fnstorage'

<span class='comment'>-- To list all the azure locations use</span>
Get-AzLocation

<span class='comment'>-- To filter locations from india </span>
Get-AzLocation | Where-Object {$_.DisplayName -contains "India"} 

<span class='comment'>-- Resource Location </span>
$Location='southindia'

<span class='comment'>-- Storage Sku </span>
$StorageSku='Standard_LRS'

<span class='comment'>-- Function Run time</span>
$RunTime='DotNet'
</pre>
<br />

# Step 4: Create Resource Group
<pre>
New-AzResourceGroup -Name $ResourceGroupName -Location $Location
</pre>
<br />

# Step 5: Create a storage account required for Azure Function App
<pre>
New-AzStorageAccount -Name $StorageName -ResourceGroup $ResourceGroupName -Location $Location -SkuName $StorageSku
</pre>
<br />

# Step 6: Create Azure Function App
<pre>
New-AzFunctionApp -Name $FunctionAppname -StorageAccountName $StorageName -Location $Location -ResourceGroupName $ResourceGroupName -FunctionsVersion $FunctionsVersion -RunTime $RunTime
</pre>

# Step 7: Verify the created Function App
<pre>
Get-AzFunctionApp
