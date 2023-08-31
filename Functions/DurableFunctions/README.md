# Durable Functions
- Allows you to implement complex stateful functions in a serverless-environment.
- Extension to Azure Functions that lets you perform long-lasting, stateful operations in Azure.
- Can use to orchestrate a long-running workflow.
- Function framework take care of activity monitoring, synchronization, and runtime concerns.
- Orchestrate long running workflows as a set of activities using Durable Functions.

- Benefits of Durable Functions
    - Enable you to write event driven code
    - Chain functions together
    - Orchestrate and coordintate functions and specify the order in which functions should execute.
    - Tha state is managed for you.

- Allows you to define stateful workflows using an orchestration function. Orchestration function benefits
    - Define workflows in code.
    - Functions can be called both synchronously and asynchronously.
    - Azure checkpoints the progress of a function automatically when the function awaits. (DeHydrate and Rehydrate the function)

- Function Types
    - **Client** - entry point for creating an instance of a Durable functions orchestration.
    - **Orchestrator** - describe how actions are executed, and the order in which they are run.
    - **Activity** - basic units of work in durable function orchestration.

- Application patterns
    - **Function chaining** - the workflow executes a sequence of functions in a specified order.

    ```mermaid
    graph TD;
        F1(Function 1) --> T1(Task 1)
        T1(Task 1) --> F2(Function 2)
        F2(Function 2) --> T2(Task 2)
        T2(Task 2) --> F3(Function 3)
    ```

    - **Fan out/fan in** - runs multiple functions in parallel and waits all the functions to finish.

    ```mermaid
    graph TD;
        F1(Function 1) --> T1(Task 1)
        T1(Task 1) --> F2(Function 2)
        T1(Task 1) --> F3(Function 3)
        T1(Task 1) --> F4(Function 4)
        F2(Function 2) --> T2(Task 2)
        F3(Function 2) --> T2(Task 2)
        F4(Function 2) --> T2(Task 2)
        T2(Task 2) --> F5(Function 5)
    ```

    - **Async HTTP APIs**- address the problem of coordinating state of long-running operations with external clients.

    - **Monitor** - implements a recurring process in a workflow, possibly looking for a change in state.

    - **Human interaction** - This pattern combines automated processes that also involve some human interaction.

- Comparision with Logic Apps

## Design a workflow based on Durable Functions

- Example
    ```mermaid
    graph TD;
        F1(Request Approval) --> T1(Approval Task)
        T1(Approval Task) --> F2(Process Approval)
        T1(Approval Task) --> F3(Escalalte)    
    ```

| Workflow function | Durable Function Type |
| ----------------- | --------------------- |
| Submitting a project design proposal for approval | Client Function |
| Assign an Approval task to relevant member of staff | Orchestration Function |
| Approval task | Activity Function |
| Escalation task | Activity Function |





