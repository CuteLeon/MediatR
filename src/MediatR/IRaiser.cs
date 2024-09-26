using System.Threading.Tasks;
using System.Threading;

namespace MediatR;

/// <summary>
/// Raise a event through the mediator pipeline to be handled by multiple handlers.
/// </summary>
public interface IRaiser
{
    /// <summary>
    /// Asynchronously raise a event to multiple handlers
    /// </summary>
    /// <param name="event">Event object</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task that represents the raise operation.</returns>
    Task Raise(object @event, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously raise a event to multiple handlers
    /// </summary>
    /// <param name="event">Notification object</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task that represents the publish operation.</returns>
    Task Raise<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
