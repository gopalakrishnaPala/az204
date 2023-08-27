<style>
    pre {
        font-size: 24px; 
    }

    .comment {
        color: green;
    }
</style>

# Step 1: Login to Azure Acount
<pre>
az login
</pre>
<br />

# Step 2: Set the Subscription
<pre>
<span class='comment'>-- Get the Subscription id from the Portal</span>
subscription="subscription id"

<span class='comment'>-- Set the Subscription</span>
az account set -s $subscription
</pre>
<br />

# Step 3: Set the Parameters for creating Azure Function App
<pre>
<span class='comment'>-- Resource Group Name </span>
resourceGroupName='gp-fnapp'

<span class='comment'>-- Function App Name </span>
functionAppName='gpdemo2fn'

<span class='comment'>-- Function Version Name - Allowed value 2, 3, 5 </span>
functionsVersion='4'

<span class='comment'>-- Storage Account Name required by Function App </span>
storageName='gpdemo2fnstorage'

<span class='comment'>-- Resource Location </span>
location='southindia'

<span class='comment'>-- Storage Sku </span>
storageSku='Standard_LRS'

<span class='comment'>-- To list all the azure locations use</span>
az account list-locations 

<span class='comment'>-- We can use jq library to query json in terminal</span>
brew install jq

<span class='comment'>-- To list only names of azure locations</span>
az account list-locations | jq -r '.[].name'
</pre>
<br />

# Step 4: Create a storage account required for Azure Function App
<pre>
az storage account create --name $storageName --resource-group $resourceGroupName --consumption-plan-location $location --sku $storageSku
</pre>
<br />

# Step 5: Create Azure Function App
<pre>
az functionapp create --name $functionAppName --resource-group $resourceGroupName --consumption-plan-location $location --storage-account $storageName --functions-version $functionsVersion
</pre>

# Step 6: Verify the created Function App
<pre>
<span class='comment'>-- Get all function apps</span>
az functionapp list

<span class='comment'>-- To get only the function app names</span>
az functionapp list | jq -r '.[].name'
</pre>