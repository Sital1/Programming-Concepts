## C# Sharp Channels

The primary problem the channels solves is the producer, consumer problem.

 - we usually resolve a service using dependency injection.
 because we exit the scope of the service before the notification is finished
the DI is disposed. When the SendNotification() tries to consume it, the problem arises.

- We might wanna use Channel. Put a message of what we want to send in the channel. When the service is ready, it can pick it  up.

### Use case

- Video processing can be solved by a channel. Take the task, put it in a channel/queue and wait 
for the consuming service to pick it up.


---

- We should be able to read and write into the channel.
- Doesn't depend ont the state and sharing memory.
- Share memory by passing into a queue(channel)

- Channel is essentially a queue that regulates the number of item, who can read, when the items can be read


- When the consumer is waiting to read, we don't want to block the thread. Hence, the reading should be asynchronous. 
   - We can use semaphore to act as a gate to let the consumer know if the items can be read.


---
After using Channels  in the UsingChannels project

We have the main task and the Notification Dispatcher as the background task. They are connected via the channel.
Whenever we put the  message in the channel, the dispatcher reads and consumes it. The dispatcher has it's own lifetime and services. It manages 
it's own states. 