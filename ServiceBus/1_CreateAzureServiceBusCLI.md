
### Login to Azure Acount
```
az login
```

### Set the Parameters for creating Azure Function App
```
resourceGroup='rg-gp-az204'                 
namespace='sb-gp-az204'                    
location='southindia'       
queue='sbq-gp-az204'             
topic='sbt-gp-az204'          
subscription1='sbs-gp-az204-1'   
subscription2='sbs-gp-az204-2' 
```

### Create Resource Group
az group create --name $resourceGroup --location $location

### Create Service Bus Namespace
```
az servicebus namespace create --name $namespace --resource-group $resourceGroup --location $location
```

### Create Service Bus Queue
```
az servicebus queue create --name $queue --namespace $namespace --resource-group $resourceGroup
```

### Create Service Bus Topic
```
az servicebus topic create --name $topic --namespace $namespace --resource-group $resourceGroup
```

### Create Service Bus Topic Subscription
```
az servicebus topic subscription create --name $subscription1 --topic $topic --namespace $namespace --resource-group $resourceGroup

az servicebus topic subscription create --name $subscription2 --topic $topic --namespace $namespace --resource-group $resourceGroup
```