using MvpCore.Events;
using MvpCore.Presenters;
using CounterExample.Events;
using CounterExample.Models;
using CounterExample.Views;

namespace CounterExample.Presenters
{
    public class CounterPresenter : PresenterBase<ICounterView, CounterModel>
    {
        public CounterPresenter(
            ICounterView view,
            CounterModel model,
            IEventPublisher eventBus
        ) : base(view, model, eventBus) { }

        protected override void OnViewEvent(ViewEvent @event)
        {
            switch (@event)
            {
                case IncrementRequestedEvent:
                    Model.Increment();
                    break;
            }
        }

        protected override void OnModelEvent(ModelEvent @event)
        {
            switch (@event)
            {
                case CounterUpdatedEvent cue:
                    View.UpdateCount(cue.NewCount);
                    break;
            }
        }
    }
}