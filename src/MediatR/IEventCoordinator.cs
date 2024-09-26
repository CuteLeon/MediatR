using System;

namespace MediatR;

/// <summary>
/// Defines a coordinator for a event
/// </summary>
/// <typeparam name="TEvent">The type of event being coordinated</typeparam>
public interface IEventCoordinator<TEvent>
    where TEvent : IEvent
{
    void Subscribe(EventHandler<TEvent> callback);

    void Unsubscribe(EventHandler<TEvent> callback);

    void OnEvent(TEvent arg);
}

/// <summary>
/// Wrapper class for a synchronous event coordinator
/// </summary>
/// <typeparam name="TEvent">The event type</typeparam>
public class EventCoordinator<TEvent> : IEventCoordinator<TEvent>
    where TEvent : IEvent
{
    protected object _lock = new();
    protected event EventHandler<TEvent>? Event;

    public void Subscribe(EventHandler<TEvent> callback)
    {
        lock (this._lock)
            this.Event += callback;
    }

    public void Unsubscribe(EventHandler<TEvent> callback)
    {
        lock (this._lock)
            this.Event -= callback;
    }

    public void OnEvent(TEvent arg)
    {
        this.Event?.Invoke(this, arg);
    }
}
