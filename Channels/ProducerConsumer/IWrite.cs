namespace ProducerConsumer;

public interface IWrite<T>
{   
    // Doesn't depend ont the state and sharing memory.
    // Share memory by passing into a queue(channel)
    void Push(T msg);

    void Complete();
}