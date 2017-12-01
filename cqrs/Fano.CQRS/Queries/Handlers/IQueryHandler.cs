namespace Fano.CQRS.Queries.Handlers
{
    using System.Threading.Tasks;
    
    /// <summary>
    /// Marker interface that makes it easier to discover handlers via reflection.
    /// </summary>
    public interface IQueryHandler { }

    /// <summary>
    /// Interface for handlers of <see cref="IQuery{TResult}"/>
    /// </summary>
    public interface IQueryHandler<TParameter, TResult> : IQueryHandler
        where TParameter : IQuery<TResult> where TResult : class
    {
        /// <summary>
        /// Handles the given query asynchronously
        /// </summary>
        /// <param name="query">Query object that implements <see cref="IQuery{TResult}"/></param>
        /// <returns>Execution result of the query</returns>
        Task<TResult> HandleAsync(TParameter query);
    }
}
