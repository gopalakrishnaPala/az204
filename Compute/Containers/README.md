# Introduction
## Containers
- Containers helps to package the application along with libraries, frameworks and dependencies that are required.
- Solves the problem of isolating an application (App dependencies, Third-party libraries)
- Portability

## Docker
- This is an open platform that is used for developing, shipping and running applications.
- Docker has the ability to package and run an application in a loosely isolated environment called a container

- **Image** - is a read-only template with instructions that are required to create the Docker container
- **Container** - is a runnable instance of an image

## Dockerhub
- Repository of images

## Running a simple Docker container
- nginx image (pull from dockerhub)
- nginx container

- List all the images
```
docker images
```

- Pull the image (can skip this step, as docker run command will pull the image)
```
docker pull nginx
```
- Create a container
```
docker run --name appnginx -p 80:80 -d nginx
```

- See the running container
```
docker ps
```

## Containerize .NET Application
- Create a new file with name `Dockerfile` (with no extension)
- Add the following content to `Dockerfile`
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "sqlapp.dll"]
```
- Build the image
```
docker build -t sqlapp .
```
- Create a container
```
docker run --name sqlapp -p 80:80 -d sqlapp
```