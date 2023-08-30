# Azure Cosmos DB
- Concepts
    - Introduction
    - Throughput an dCost
    - Horizontal Partitioning
    - Global Distribution

- How-to
    - Data Modeling and Migration
    - Querying with SQL
    - Programming with the .NET SDK
    - Advanced Programming Features
    - Management and Security
    - Using the Gremlin API

## NoSQL
- Big Data
    - Volume  (Scale out - terabytes, petabytes)
    - Velocity (throughput)
    - Varity  (schema)

- *Distributes* - Replicas ensure high availability and resilence
- *Scale-out* - Horizontal partitioning for elastic storage and throughput
- *Schema-free* - No enforced schema. No defined shape

## Cosmos DB
- Massively scalalbe NoSQL database
    - Fully managed Azure PaaS
    - Single-digit millisecond reads and writes

- Automatic Horizontal Partitioning
    - Elastic scale for both storage and throughput

- Global distribution
    - Point-and-click geo-replication
    - Multiple write regions

- Multi-model/Multi-API
    - Not exclusively a document database
    - Also supports table, graph, and columnar

### Create a Cosmos DB

- Capacity 
    - Provisiioned thorughput
    - Serverless

- Global Distribution

#### Creat Container
- Data Explorer

- Need to create multiple containers based on
    - Throughput - performance
    - Partition - How data is seggregated

- Analytics store

- Container
    - Items

    - Single partition query, cross partition query

- Management Options
    - Azure Portal
    - Azure CLI
    - PowerShell
    - ARM Templates
    - Notebooks
    - REST API

- Creating a simple Notebook
    - 

- Automatic Indexing
    - Indexed entries for querying

- Multiple APIs and Data Models
    - SQL API
        - JSON Document
        - SQL queries
    
    - MangoDB API
        - BSON Document
        - MangoDB queries
        ---- Standard DB Driver support

    - Table API
        - Key-Value
        - Azure Table Storage
    
    - Gremlin API
        - Graph
        - Vertices and Edges
    
    - Cassandra API
        - Columnar
        - Schema

-
    - Global Distribution
    - Horizontal Partitioning
    - Automatic Indexing
    - Provisioned Throughput

- Atom Record Sequence (ARS)
    - It's all ARS under the covers, projected as any desired data model

## Throughput and Cost

- Measuring Performance
    - **Latency** - How fast is the response for a given request?  
    - **Throughput** - How many requests can be served within a specific period of time?

- Request Units
    - **Throughput Currency** - Blended measure of computational cose => % Memory + % CPU + % IOPs
    - **All Requests are not equal** - Every Cosmos DB response header show the RU charge for the request
    - **Request Units are Deterministic** - The same request will always require the same number of request units

- Monitoring Request Unit Consumption
    - Query Stats

- Throughput Offers
    | **Provisioned throughput (manual)** | **Provisioned throughput (autoscale)** | **Serverless**                     |
    | ----------------------------------- | -------------------------------------- | ---------------------------------- |
    | Reserve RU/sec                      | Reserve max RU/sec                     | Consumption model                  |
    | Guaranteed always available         | Scales up and down automatically       | No Provisioned throughput          |
    | Can lower and raise as needed       | From max to 10% below                  | Pay only for the RUs that you use  |
    | Better for predictable workload     | better for un predicatable workload    | Better for spiky workloads         |

    














