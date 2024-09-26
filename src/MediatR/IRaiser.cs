using System.Threading.Tasks;
using System.Threading;

namespace MediatR;

/// <summary>
/// Raise a event through the mediator pipeline to be handled by multiple coordinators.
/// </summary>
public interface IRaiser
{
    /// <summary>
    /// Asynchronously raise a event to multiple coordinators
    /// </summary>
    /// <param name="event">Event object</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task that represents the raise operation.</returns>
    Task Raise<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
