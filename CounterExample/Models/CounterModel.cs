using MvpCore.Events;
using MvpCore.Interfaces;
using CounterExample.Events;

namespace CounterExample.Models
{
    public class CounterModel : IModel
    {
        private int _count;
        private readonly IEventPublisher _eventBus;

        public CounterModel(IEventPublisher eventBus) => _eventBus = eventBus;

        public void Increment()
        {
            _count++;
            _eventBus.Publish(new CounterUpdatedEvent(_count));
        }
    }
}
