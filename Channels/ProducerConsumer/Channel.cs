using System.Collections.Concurrent;

namespace ProducerConsumer;

public class Channel<T>:IRead<T>, IWrite<T>
{

    private bool Finished { get; set; }
    private ConcurrentQueue<T> _queue;
    private SemaphoreSlim _flag;

    public Channel()
    {
        _queue = new ConcurrentQueue<T>();
        // When the channel is created, there is no item in the queue.
        _flag = new SemaphoreSlim(0);
    }
    
    public void Push(T msg)
    {
        // push stuff into the queue
        _queue.Enqueue(msg);
        // consumer, you can come and read the message. There can be multiple producer and consumer
        _flag.Release();
    }


    public async Task<T> Read()
    {
        // The thread is going to come here and leave. Unless there is someting in the queue and the gate has been opened.
        await _flag.WaitAsync();

        // read from the Queue.
      if (_queue.TryDequeue(out var msg))
      {
          return msg;
      }

      return default;
    }



    public bool IsComplete()
    {
        return Finished && _queue.IsEmpty;
    }


    public void Complete()
    {
        Finished = true;
    }


}