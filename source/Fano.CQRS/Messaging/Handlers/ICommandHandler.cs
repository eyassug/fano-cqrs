namespace Fano.CQRS.Messaging.Handlers
{
    using System.Threading.Tasks;

    /// <summary>
    /// Marker interface that makes it easier to discover handlers via reflection.
    /// </summary>
    public interface ICommandHandler { }

    // Interface for command handlers - has a type parameters for the command
    public interface ICommandHandler<in TParameter>: ICommandHandler
        where TParameter : ICommand
    {
        /// <summary>
        /// Handles the given command asynchronously
        /// </summary>
        /// <param name="command">Command object that implements ICommand</param>        
        Task HandleAsync(TParameter command);
    }
}
