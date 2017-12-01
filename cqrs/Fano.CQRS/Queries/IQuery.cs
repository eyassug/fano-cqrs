namespace Fano.CQRS.Queries
{
    /// <summary>
    /// Represents a query.
    /// </summary>
    public interface IQuery<TResult> where TResult : class
    {
    }
}
