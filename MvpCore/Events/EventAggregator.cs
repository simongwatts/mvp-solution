using System.Collections.Concurrent;

namespace MvpCore.Events
{
    public class EventAggregator : IEventPublisher
    {
        private readonly ConcurrentDictionary<Type, List<Subscription>> _subscriptions = new();

        public void Publish<TEvent>(TEvent @event)
        {
            var eventType = typeof(TEvent);
            var allTypes = GetBaseTypesIncludingSelf(eventType);

            foreach (var type in allTypes)
            {
                if (_subscriptions.TryGetValue(type, out var handlers))
                {
                    foreach (var handler in handlers.ToArray())
                    {
                        handler.Invoke(@event!);
                    }
                }
            }
        }
        public IDisposable Subscribe<TEvent>(Action<TEvent> handler)
        {
            var type = typeof(TEvent);
            var sub = new Subscription<TEvent>(handler, RemoveSubscription);
            _subscriptions.AddOrUpdate(
                type,
                _ => new List<Subscription> { sub },
                (_, existing) =>
                {
                    existing.Add(sub);
                    return existing;
                });
            return sub;
        }

        private void RemoveSubscription(Subscription subscription)
        {
            if (_subscriptions.TryGetValue(subscription.EventType, out var subs))
            {
                _subscriptions[subscription.EventType] = subs.Where(s => s != subscription).ToList();
            }
        }

        private static IEnumerable<Type> GetBaseTypesIncludingSelf(Type type)
        {
            var types = new HashSet<Type> { type };
            var current = type.BaseType;

            while (current != null)
            {
                types.Add(current);
                current = current.BaseType;
            }

            foreach (var interfaceType in type.GetInterfaces())
            {
                types.Add(interfaceType);
            }

            return types;
        }

        private abstract class Subscription : IDisposable
        {
            public Type EventType { get; }
            protected Subscription(Type eventType) => EventType = eventType;
            public abstract void Invoke(object @event);
            public abstract bool Matches(object handler);
            public abstract void Dispose();
        }

        private sealed class Subscription<TEvent> : Subscription
        {
            private Action<TEvent>? _handler;
            private readonly Action<Subscription> _removeAction;

            public Subscription(Action<TEvent> handler, Action<Subscription> removeAction)
                : base(typeof(TEvent))
            {
                _handler = handler;
                _removeAction = removeAction;
            }

            public override void Invoke(object @event)
            {
                if (@event is TEvent typedEvent)
                {
                    _handler?.Invoke(typedEvent);
                }
            }

            public override bool Matches(object handler) =>
                ReferenceEquals(_handler, handler as Action<TEvent>);

            public override void Dispose()
            {
                _removeAction(this);
                _handler = null;
            }
        }
    }
}