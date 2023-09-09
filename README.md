# Exam AZ-204: Developing Solutions for Microsoft Azure

> For more details refer to 🌟 [Microsoft Certification Page](https://learn.microsoft.com/en-us/certifications/exams/az-204/) 🌟 

## Skills Measured
- **Develop Azure compute solutions (25–30%)**
- **Develop for Azure storage (15–20%)**
- **Implement Azure security (20–25%)**
- **Monitor, troubleshoot, and optimize Azure solutions (15–20%)**
- **Connect to and consume Azure services and third-party services (15–20%)**

### For more details refer
> - 🌟 [Skills measuered](AZ-204_StudyGuide_ENU_FY23Q3_v2.pdf) 🌟 
> - 🌟 [Exam readiness zone](https://learn.microsoft.com/en-us/shows/exam-readiness-zone) 🌟
> - 🌟 [Training course](https://learn.microsoft.com/en-us/training/courses/az-204t00) 🌟 

## [Develop Azure compute solutions (25–30%)](Compute/README.md)
- [Implement containerized solutions](Compute/Containers/README.md)
    - Create and manage container images for solutions
        - Task Scenarios
            - Quick task
            - Automatically triggered tasks
            - Multi-step task (familiarity YAML file for configuring tasks)
    - Publish an image to Azure Container Registry
        - Use cases (Pull images from ACR to various deployment targes)
            - Scalable orchestration
            - Azure services
        - Container Registry service tiers
        - Supported images and artifacts
        - Azure Container Registry tasks
    - Run containers by using Azure Container Instance
        - Features
        - Deployment (YAML files and ARM templates)
        - Resource allocation  (Container Groups)
        - Networking
        - Storage
        - Common scenarios (Multi container groups)
    - Create solutions by using Azure Container Apps
        - Use Container Apps to
            - Deploy API endpoints
            - Host background processing applications
            - Handle event-driven processing
            - Run microservices
        - Apps to dynamically scale on 
            - HTTP traffic
            - Event-driven processing
            - CPU or memory load
            - Any KEDA-support scaler

- [Implement Azure App Service Web Apps](Compute/AppService/README.md)
    - Create an Azure App Service Web App
    - Enable diagnostics logging
    - Deploy code to a web app
    - Configure web app settings including SSL, API settings, and connection strings
    - Implement autoscaling

- [Implement Azure Functions](Compute/Functions/README.md)
    - Create and configure an Azure Function App
    - Implement input and output bindings
    - Implement function triggers by using data operations, timers, and webhooks

## Monitor, troubleshoot, and optimize Azure solutions (15–20%)
- [Implement caching for solutions](Caching/README.md)
    - Configure cache and expiration policies for Azure Cache for Redis
    - Implement secure and optimized application cache patterns including data sizing, connections, encryption, and expiration
- [Troubleshoot solutions by using metrics and log data](Monitor/README.md)
    - Configure an app or service to use Application Insights
    - Review and analyze metrics and log data
    - Implement Application Insights web tests and alerts


