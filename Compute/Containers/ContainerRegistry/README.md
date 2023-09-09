# Azure Container Registry
## Introduction
- **Dockerhub** - Repository of images
- Managed private Docker Registry Service
- Container images can be pushed and pulled with the help of `Docker CLI` and `Azure CLI'S`
- Azure Container Registry Tasks can build container images in Azure

## Create an Azure Container Registry
- Declare variable
    ```
    resourceGroup='rg-gp-az204'
    location='southindia'
    acrName='acrgpaz204'
    containerName='samplewebapp'
    ```

- Create Resource Group
    ```
    az group create --name $resourceGroup --location $location
    ```

- Create Azure Container Registry
    ```
    az acr create --name $acrName --resource-group $resourceGroup --location $location --sku Premium
    ```
    **Note:** A premium sku is required for geo replication

## Build Container images with Azure Container Registry Tasks
- Copy the code to editor
    ```dockerfile
    FROM    node:9-alpine
    ADD     https://raw.githubusercontent.com/Azure-Samples/acr-build-helloworld-node/master/package.json /
    ADD     https://raw.githubusercontent.com/Azure-Samples/acr-build-helloworld-node/master/server.js /
    RUN     npm install
    EXPOSE  80
    CMD     ["node", "server.js"]
    ```

- Save as **Dockerfile** file (without extension)

- Run the command
    ```
    az acr build --registry $acrName --image $containerName:v1 .
    ```

- Verify the image
    ```
    az acr repository list --name $acrName --output table
    ```

## Deploy Images from Container Registry
 - Can pull images using container management platforms like
    - Azure Container Instance
    - Azure Kubernetes service
    - Docker for Windows or Mac

- ACR doesn't support un authenticated access. Registries support 2 types of authentications
    - **Azure Active Directory Authentication** - Both user and service principals using RBAC (reader, contributor, or owner)
    - **Admin Account** included with each account. Disabled by default

- Enable Registry Admin Account
    ```
    az acr update --name $acrName --admin-enabled true
    ```

- Retrieve username and password for admin account
    ```
    az acr credential show --name $acrName
    ```

- Login to Container Registy
    ```
    az acr login --name $acrName --username [username] --password [password]
    ```

- Deploy Container
    ```
    az container create \
        --resource-group $resourceGroup
        --name $containerName
        --image $acrName.azurecr.io/helloacrtasks:v1 \
        --registry-login-server $acrName.azurecr.io \
        --ip-address Public \
        --location $location \
        --userName [username] \
        --password [password]
    ```

- Get the Ip address of the azure container instance
    ```
    az container show --resource-group $resourceGroup --name $containerName --query ipAddress.ip --output table
    ```

## Replicate Container Images to Regions
- A geo replicated registry provides the following benefits
    - Single registry/image/tag names can be used across multiple regions
    - Network-close registry access from regional deployments
    - No extra egress fee
    - Single management of registry across multiple regions

- Create a replicated region for Azure Container Registry
    - run the below command
        ```
        az acr replication create --registry $acrName --location centralindia
      ```

    - retrieve all container image replicas created
        ```
        az acr replication list --registry $acrName --output table
        ```

## Multi-stage builds
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from-build /source/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "sqlapp.dll"]
```

## Deploy to the Azure Container Instance
- Declare variable
    ```
    resourceGroup='rg-gp-az204'
    location='southindia'
    acrName='acrgpaz204'
    containerName='samplewebapp'
    ```

- Deploy Container
    ```
    az container create \
        --resource-group $resourceGroup
        --name $containerName
        --image $acrName.azurecr.io/helloacrtasks:v1 \
        --registry-login-server $acrName.azurecr.io \
        --ip-address Public \
        --location $location \
        --userName [username] \
        --password [password]
    ```

- Get the Ip address of the azure container instance
    ```
    az container show --resource-group $resourceGroup --name $containerName --query ipAddress.ip --out