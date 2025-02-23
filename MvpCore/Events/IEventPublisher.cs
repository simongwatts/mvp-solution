
namespace MvpCore.Events
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event);
        IDisposable Subscribe<TEvent>(Action<TEvent> handler);
    }
}