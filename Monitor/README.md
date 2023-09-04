# Azure Monitor overview
Azure Monitor is a comprehensive monitoring solution for collecting, analyzing, and responding to monitoring data from cloud and on-premises environments.

The below image shows the high level architecture of Azure Monitor.
![Azure CLI Documentation](./images/overview.svg)

## Application Insights
Application Insights is an extension of Azure Monitor and provides Application Performance monitoring ("APM") features.

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


