# Azure Service Bus Overview
Fully Managed Enterprise Message Broker with
- Message Queues
- Publish-Subscribe Topics
Used to decouple applications and services from each other.

# Message
Message is a container decorated with meta data, and contains data.

# Queues
- The messages in the queue are ordered
- The messages are held in triple-redundant storage
- The data is available across availibility zones, if enabled
- The messages can then be retrieved via the pull mode

# Topics
- The Subscriber to the topic will receive a copy ot eh message sent to the topic
- We can write rules which contains filters on each subscription. The filter will decide which messages are received by Subscription

# NameSpaces
A namespace is the container for all the messaging components (queues and topics). Multiple queues and topics can be in a single namespace

### Advanced Features

#### Message sessions
To realize FIFO guarantee in processing messagesi in Service Bus queues or Subscriptions.

*Note:* If messages just need to be retrieved in order, you don't need to use sessions. If messages need to be processed in order, use sessions.

#### Auto-forwarding
Enabled to chain a queue or subscription to another queue or topic that is part of the same namespace

#### Dead-lettering
Service Bus queues and topic subscriptions provide a secondary subqueue, called a Dead-letter queue (DLQ). DLQ holds messages that can't be delivered to any receivers, or the messages that can't be processed.

#### Scheduled delivery
Can submit messages to a queue or topic for a delayed processing

#### Message deferal
When a queue or subscription client receives a message that it's willing to process. but for which the processing is not possible because of special circumstances within the application, the entity can defer retrival of the message to later point.

#### Transactions
A transaction groups two or more operations together into an execution scope.

#### Filters and actions
Subscribers can define which messages they want to receive from a topic. These messages are specified in the form of one or more named subscription rules.

#### Auto-delete on idle
Auto-delete on idle enables you to specify an idle interval after which the queue is automatically deleted.

#### Duplicate detection
If an error occurs that causes the client to have any doubt about the outcome of a send operation, duplicate detection takes the doubt out of these situations by enabling the sender to resend the same message, and the queue or topic discards any duplicate copies.

## Create Azure Service Bus Component
- Using [Azure CLI](1_CreateAzureServiceBusCLI.md)




