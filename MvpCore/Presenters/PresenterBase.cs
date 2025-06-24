using MvpCore.Events;
using MvpCore.Interfaces;

namespace MvpCore.Presenters
{
    /// <summary>
    /// Base class for all presenters using MVP pattern
    /// </summary>
    /// <typeparam name="TView">Type of view interface</typeparam>
    /// <typeparam name="TModel">Type of model interface</typeparam>
    public abstract class PresenterBase<TView, TModel> : IPresenter<TView, TModel>
        where TView : class, IView
        where TModel : class, IModel
    {
        protected TView? _view;
        protected readonly TModel _model;
        protected readonly IEventPublisher _eventBus;
        private readonly List<IDisposable> _subscriptions = new();

        public TView? View => _view;
        public TModel Model => _model;

        protected PresenterBase(TView view, TModel model, IEventPublisher eventBus)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        // Alternate constructor for DI scenarios where view is set later
        protected PresenterBase(TModel model, IEventPublisher eventBus)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public void SetView(TView? view)
        {
            _view = view;
        }

        public virtual void Initialize()
        {
            // Subscribe to common events here
            Subscribe<ViewEvent>(OnViewEvent);
            Subscribe<ModelEvent>(OnModelEvent);
            Subscribe<ViewReadyEvent<TView>>(OnViewReadyEvent);

            UpdateView();
        }

        protected virtual void UpdateModel() { }
        protected virtual void UpdateView() { }

        protected virtual void OnViewEvent(ViewEvent @event) 
        {
            UpdateModel();
        }
        protected virtual void OnModelEvent(ModelEvent @event) 
        {
            UpdateView();
        }
        protected virtual void OnViewReadyEvent(ViewReadyEvent<TView> @event) 
        {
            SetView(@event.View);
            UpdateView();
        }

        protected void Subscribe<TEvent>(Action<TEvent> handler)
        {
            _subscriptions.Add(_eventBus.Subscribe(handler));
        }

        public virtual void Dispose()
        {
            foreach (var subscription in _subscriptions)
            {
                subscription.Dispose();
            }
            _subscriptions.Clear();
        }
    }
}