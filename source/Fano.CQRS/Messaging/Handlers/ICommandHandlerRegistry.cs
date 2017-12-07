namespace Fano.CQRS.Messaging.Handlers
{
    public interface ICommandHandlerRegistry
    {
        void Register(ICommandHandler handler);
    }
}
