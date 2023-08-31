- Set the Parameters for creating Azure Function App

> {% note %} To list all the <mark>azure locations use</mark>. {% endnote %}

    ```
    az account list-locations --output table
    ```
    
    ```
    resourceGroup='rg-gp-az204'
    location='southindia'
    functionApp='func-gp-az204'
    functionsVersion='4'
    storage='stgpaz204'
    storageSku='Standard_LRS'
    runtime='dotnet-isolated'
    runtimeVersion='6'
    ```

- Create Resource Group
    ```
    az group create --name $resourceGroup --location $location
    ```

- Create a storage account associated with Function Appp
    ```
    az storage account create --name $storage --resource-group $resourceGroup --location $location --sku $storageSku
    ```

- Create Azure Function App

     *<u>Help</u>*To list all the azure locations use
    ```
    az functionapp list-runtimes
    ```
    
    ```
    az functionapp create --name $functionAppName --resource-group $resourceGroup --consumption-plan-location $location --storage-account $storage --functions-version $functionsVersion --runtime $runtime --runtime-version $runtimeVersion
    ```
- Verify the created Function App
    ```
    az functionapp list
    ```

- Delete the resouce group
    ```
    az group delete --name $resourceGroupName
    ```
