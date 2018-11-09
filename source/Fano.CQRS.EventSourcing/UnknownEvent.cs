namespace Fano.CQRS.EventSourcing
{
    /// <summary>
    /// Represents an event that cannot be mapped to any known types.
    /// </summary>
    public sealed class UnknownEvent : VersionedEvent
    {
        
    }
}