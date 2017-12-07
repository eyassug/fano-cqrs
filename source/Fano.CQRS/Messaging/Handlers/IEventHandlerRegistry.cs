namespace Fano.CQRS.Messaging.Handlers
{
    public interface IEventHandlerRegistry
    {
        void Register(IEventHandler handler);
    }
}
