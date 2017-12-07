namespace Fano.CQRS.Messaging.Handlers
{
    using System.Threading.Tasks;
    /// <summary>
    /// Marker interface that makes it easier to discover handlers via reflection.
    /// </summary>
    public interface IEventHandler { }

    public interface IEventHandler<T> : IEventHandler
        where T : IEvent
    {
        Task HandleAsync(T @event);
    }

    public interface IEnvelopedEventHandler<T> : IEventHandler
        where T : IEvent
    {
        Task HandleAsync(Envelope<T> envelope);
    }
}
