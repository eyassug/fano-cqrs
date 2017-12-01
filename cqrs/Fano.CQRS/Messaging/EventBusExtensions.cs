namespace Fano.CQRS.Messaging
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides usability overloads for <see cref="IEventBus"/>
    /// </summary>
    public static class EventBusExtensions
    {
        public static async Task PublishAsync(this IEventBus bus, IEvent @event)
        {
            await bus.PublishAsync(new Envelope<IEvent>(@event));
        }

        public static async Task PublishAsync(this IEventBus bus, IEnumerable<IEvent> events)
        {
            await bus.PublishAsync(events.Select(x => new Envelope<IEvent>(x)));
        }
    }
}
