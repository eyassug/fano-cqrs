namespace Fano.CQRS.Queries.Handlers
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by Dispatchers that dispatch queries to their respective handler
    /// </summary>
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query) where TResult : class;
    }
}
