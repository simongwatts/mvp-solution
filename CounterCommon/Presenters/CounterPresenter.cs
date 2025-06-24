using MvpCore.Events;
using MvpCore.Presenters;
using CounterCommon.Events;
using CounterCommon.Models;
using CounterCommon.Views;
using System.ComponentModel.Design;

namespace CounterCommon.Presenters
{
    public class CounterPresenter : PresenterBase<ICounterView, CounterModel>
    {
        public CounterPresenter(
            ICounterView view,
            CounterModel model,
            IEventPublisher eventBus
        ) : base(view, model, eventBus) 
        {
        }

        // Alternate constructor for DI scenarios where view is set later
        public CounterPresenter(
            CounterModel model,
            IEventPublisher eventBus
        ) : base(model, eventBus) 
        { 
        }

        protected override void OnViewEvent(ViewEvent @event)
        {
            switch (@event)
            {
                case IncrementRequestedEvent:
                    Model.Increment();
                    break;
                
                default:
                    base.OnViewEvent(@event);
                    break;
            }
        }

        protected override void OnModelEvent(ModelEvent @event)
        {
            switch (@event)
            {
                case CounterUpdatedEvent cue:
                    View?.UpdateCount(cue.NewCount);
                    break;

                default:
                    base.OnModelEvent(@event);
                    break;
            }
        }

        protected override void UpdateView()
        {
            View?.UpdateCount(Model.Count);
        }
    }
}