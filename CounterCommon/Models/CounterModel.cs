using MvpCore.Events;
using MvpCore.Interfaces;
using CounterCommon.Events;

namespace CounterCommon.Models
{
    public class CounterModel : IModel
    {
        private int _count;
        private readonly IEventPublisher _eventBus;

        public CounterModel(IEventPublisher eventBus) => _eventBus = eventBus;

        public int Count => _count;

        public void Increment()
        {
            _count++;
            _eventBus.Publish(new CounterUpdatedEvent(_count));
        }
    }
}
