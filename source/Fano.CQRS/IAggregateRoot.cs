namespace Fano.CQRS
{
    using System;

    /// <summary>
    /// Interface that represents an identifiable entity in the system.
    /// </summary>
    /// <typeparam name="TId">The type parameter of the unique Id of the Aggregate Root.</typeparam>
    public interface IAggregateRoot<TId> where TId : struct
    {
         TId Id { get; }
    }
}