## C# Sharp Channels

The primary problem the channels solves is the producer, consumer problem.

 - we usually reslove a service using dependency injection.
 because we exit the scope of the service before the notification is finished
the DI is disposed. When the SendNotification() tries to consume it, the problem arises.

- We might wanna use Channel. Put a message of what we want to send in the channel. When the service is ready, it can pick it  up.

### Use case

- Video processing can be solved by a channel. Take the task, put it in a channel/queue and wait 
for the consuming service to pick it up.