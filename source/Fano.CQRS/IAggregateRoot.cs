namespace Fano.CQRS
{
    using System;

    /// <summary>
    /// Represents an identifiable entity in the system.
    /// </summary>
    public interface IAggregateRoot
    {
         Guid Id { get; }
    }
}