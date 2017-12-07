namespace Fano.CQRS.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommandBus
    {
        Task SendAsync(Envelope<ICommand> command);
        Task SendAsync(IEnumerable<Envelope<ICommand>> commands);
    }
}
