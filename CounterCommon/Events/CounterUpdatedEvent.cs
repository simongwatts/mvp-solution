using MvpCore.Events;

namespace CounterCommon.Events
{
    public class CounterUpdatedEvent : ModelEvent
    {
        public int NewCount { get; }
        public CounterUpdatedEvent(int count) => NewCount = count;
    }
}
