namespace Fano.CQRS.EventSourcing
{
    using System;
    using System.Threading.Tasks;
    
    public interface IEventSourcedRepository<T, TKey> where T : IEventSourced<TKey>
    {
        /// <summary>
        /// Tries to retrieve the event sourced entity.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The hydrated entity, or null if it does not exist.</returns>
        T Find(TKey id);
        // <summary>
        /// Tries to retrieve the event sourced entity.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The hydrated entity, or null if it does not exist.</returns>
        Task<T> FindAsync(TKey id);
        /// <summary>
        /// Retrieves the event sourced entity asynchronously.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The hydrated entity</returns>
        /// <exception cref="EntityNotFoundException">If the entity is not found.</exception>
        T Get(Guid id);

        /// <summary>
        /// Retrieves the event sourced entity asynchronously.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The hydrated entity</returns>
        /// <exception cref="EntityNotFoundException">If the entity is not found.</exception>
        Task<T> GetAsync(TKey id);

        /// <summary>
        /// Saves the event sourced entity.
        /// </summary>
        /// <param name="eventSourced">The entity.</param>
        /// <param name="correlationId">A correlation id to use when publishing events.</param>
        void Save(T eventSourced, string correlationId);

        /// <summary>
        /// Saves the event sourced entity asynchronously.
        /// </summary>
        /// <param name="eventSourced">The entity.</param>
        /// <param name="correlationId">A correlation id to use when publishing events.</param>
        Task SaveAsync(T eventSourced, string correlationId);
    }
}
