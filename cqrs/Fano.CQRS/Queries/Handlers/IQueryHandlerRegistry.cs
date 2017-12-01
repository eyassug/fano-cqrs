namespace Fano.CQRS.Queries.Handlers
{
    public interface IQueryHandlerRegistry
    {
        void Register(IQueryHandler handler);
    }
}
