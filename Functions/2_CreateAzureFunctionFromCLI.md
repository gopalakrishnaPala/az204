## Step 1: Login to Azure Acount
az login

## Step 2: Set the Subscription
subscription="<subscription id>" 
az account set -s $subscription

## Step 3: Set the Parameters for creating Azure Function App
resourceGroupName='gp-fnapp'
functionAppName='gpdemo2fn'
functionsVersion='4'
storageName='gpdemo2fnstorage'
location='southindia'
storageSku='Standard_LRS'

<!-- To list down all the azure location we can use  -->
<!-- az account list-locations -->

<!-- We can use jq library to query json in terminal -->
<!-- brew install jq  -->
<!-- To list only names of azure locations -->
<!-- az account list-locations | jq -r '.[].name' -->

## Step 4: Create a storage account required for Azure Function App
az storage account create --name $storageName --resource-group $resourceGroupName --consumption-plan-location $location --sku $storageSku

## Step 5: Create Azure Function App
az functionapp create --name $functionAppName --resource-group $resourceGroupName --consumption-plan-location $location --storage-account $storageName --functions-version $functionsVersion

## Step 6: Verify the created Function App
az functionapp list

<!-- To get only the function app names -->
az functionapp list | jq -r '.[].name'


