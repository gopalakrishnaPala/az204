# Azure Monitor overview

## Learning Reference 
 🌟 [Azure Monitor](https://learn.microsoft.com/en-us/training/paths/monitor-usage-performance-availability-resources-azure-monitor/) 🌟

## Introduction to Monitoring
Monitoring tracks the state, health, behavior, and performance of your applications and IT environment.

Monitoring includes the following key activities
- Data collection
- Data analysis
- Alerts
- Visualization
- Diagnostics and troubleshooting

Monitoring provides the following important benefits
- Performance and cost optimization
- Proactive management
- Reliability
- Capacity planning
- Security monitoring
- Compliance and goverance monitoring

## Overview of Azure Monitor
Azure Monitor is a comprehensive monitoring solution for collecting, analyzing, and responding to monitoring data from cloud and on-premises environments.

The below image shows the high level architecture of Azure Monitor.
![Azure CLI Documentation](./images/overview.svg)

- Data collection and storage
- Data analysis and response
- Alerts, workbooks, and visualizations

## Metrics and Logs
- ***Metrics** are quantitative measurements that show snapshots of application or resource performance. Example: CPU usage, memory usage, network latency, and transaction rates.
- Azure Monitor collects serveral types of metrics, including:
    - **Azure platform metrics**
    - **Custom metrics**
    - **Prometheus metrics** - collects metrics from AKS or other Kubernetes clusters.
- ***Logs*** are textual records of events, actions, and messages that occur in a resource or applications. Logs can include the following data:
    - **Text*
    - **Unstructured data**
    - **Contextual information**

- Azure Monitor Logs is a feature of Azure Monitor that lets you store, manage, and analyze log and performance data from monitored resources. To collect and analyze data, need to set up a common workspace called a Log Analytics workspace. Can configure resources to send their data to that workspace.

## Azure Monitor Insights, visualizations, and actions
### Insights
Insights are large, scalable, curated visualizations.

#### Application Insights
- Application Insights provides application performance monitoring (APM) from app development, through test, and into production.
- Can use Application Insights to collect and store application trace logging data.
- Supports distributed tracing, which is also know as distributed component correlation.
- Application Insights includes the following features
    - Live metrics
    - Availability monitoring
    - Usage monitoring
    - Smart detection
    - Application Map

#### Container Insights
Container Insights gives performance visibility into containerized workloads deployed to Azure Kubernetes Services (AKS) or Azure Container Instances.

#### VM Insights
moniters and analyzes the performance and health of Azure Windows and Linux VMs, including VMs hosted on-premises or in another cloud.

#### Network Insights
provides a comprehensive visual representation of health and metrics for all deployed network resources through topologies, without requiring any configuration.

### Visualizations
#### Workbooks
provide a flexible canvas for analyzing data and creating rich visual reports in the Azure portal.

#### Dashboards
lets you combine different kinds of data into a single pane in Azure portal.

#### Power BI
#### Grafana

### Actions
#### Artificial Intelligence for IT Operations (AIOps)
describes the application of artificial intelligence and machine learning techniques to enhance and automate aspects of IT operations and infrastructure management.

#### Azure Monitor alerts
Alerts notify you of critical conditions and take corrective action. Alert rules can be based on metric or log data.
- Alert rules use action groups, which can take actions such as sending email or SMS notifications.

#### Autoscale
lets you dynamically adjust the number of resources running to handle the load on your applications.


## Application Insights
Application Insights is an extension of Azure Monitor and provides Application Performance monitoring ("APM") features.
- Data collection and storage
- Data analysis and response
- Alerts, workbooks, and visualizations


### Features Overview
| Featured | Description |
| -------- | ----------- |
| Live Metrics | Observe activity from deployed application in real time |
| Avialbility | Synthetic Transaction Monitoring , to probe overall availability and responsiveness over time |
| GitHub or Azure DevOps Integration | Create GitHub or Azure DevOps work items in context of Application insights data. |
| Usage | Understand which features are popular with users |
| Smart Detection | Automatic failure and Anamoly detection through proactive telemetry analysis. |
| Application Map | High level top-down view of the application architecture |
| Distributed Tracing | Search and visualize and end-to-end flow of a given execution or transaction. |

### What Application Insights monitors
- Request rates, response times, and failure rates
- Dependency rates, response times, and failure rates
- Page views and load performance
- Exceptions
- AJAX calls
- User session counts
- Performance counters
- Host diagnostics
- Diagnostic trace logs
- Custom events and metrics

### Discover log-based metrics
Application Insights log-based metrics let you analyze the health of monitored apps, create powerful dashboards, and configure alerts.
Two kinds of metrics
- **Log-based metrics**
- **Standard metrics** stored as pre-aggregated time series.

### Instrument an app for monitoring
Application Insights is enabled through either *Auto-Instrumentation (agent)* or by adding *Application Insights SDK* to application code.

- Auto-Instrumentation
    - All you have to do is enable and in some cases, configure the agent, which collects the telemetry automatically.

- Enabling via Application Insights SDKs
    Need to install Application Insights SDK in the following circumstances
    - require custom events and metrics
    - require control over the flow of telemetry
    - Auto-Instrumentation is not available

- Enable via OpenCensus
    OpenCensus is an open source, vendor-agnostic, single distribution of libraries to provide metrics collection and distributed tracing of services.

### Select an availability test
Can set up recurring tests to monitor availability and responsiveness.
Three types of availability tests
- **URL ping test(classic)**
- **Standard test(preview)**
- **Custom TrackAvailability test** 

### Troubleshoot app performance by using Application Map
- Each node on the map represents an application component or its dependencies; has an
    - Health KPI
    - Alert status

## Azure Monitor Service
### Setting up Alerts
- Setting Static Alerts
- Setting Dynamic thresholds
    Azure Monitor uses Machine learning to check the historical behavior of metrics.

    - Sensitivity
        - High
        - Medium
        - Low

## Log Analytics Workspace
- Central solution for all logs.
    - kusto query language
    - marketplace solutions

- Query using Powershell


