namespace Fano.CQRS.Messaging
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides usability overloads for <see cref="ICommandBus"/>
    /// </summary>
    public static class CommandBusExtensions
    {
        public static async Task SendAsync(this ICommandBus bus, ICommand command)
        {
            await bus.SendAsync(new Envelope<ICommand>(command));
        }

        public static async Task SendAsync(this ICommandBus bus, IEnumerable<ICommand> commands)
        {
            await bus.SendAsync(commands.Select(x => new Envelope<ICommand>(x)));
        }
    }
}
