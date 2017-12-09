namespace Fano.CQRS
{
    using System;
    using System.Threading.Tasks;
    /// <summary>
    /// Represents a temporary data context to load and save an entity that implements <see cref="IAggregateRoot"/>.
    /// </summary>
    /// <typeparam name="T">The entity type that will be retrieved or persisted.</typeparam>
    public interface IAggregateRepository<T> where T : IAggregateRoot
    {
         Task<T> FindAsync(Guid id);

         Task SaveAsync(T aggregate);
    }
}