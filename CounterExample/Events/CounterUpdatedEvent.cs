using MvpCore.Events;

namespace CounterExample.Events
{
    public class CounterUpdatedEvent : ModelEvent
    {
        public int NewCount { get; }
        public CounterUpdatedEvent(int count) => NewCount = count;
    }
}
