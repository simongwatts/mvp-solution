using Xunit;
using Moq;
using CounterCommon.Models;
using CounterCommon.Presenters;
using CounterCommon.Views;
using CounterCommon.Events;
using MvpCore.Events;

namespace CounterCommon.Tests
{
    public class CounterModelTests
    {
        [Fact]
        public void Increment_IncreasesCountAndPublishesEvent()
        {
            var eventBusMock = new Mock<IEventPublisher>();
            var model = new CounterModel(eventBusMock.Object);

            model.Increment();

            Assert.Equal(1, model.Count);
            eventBusMock.Verify(e => e.Publish(It.Is<CounterUpdatedEvent>(ev => ev.NewCount == 1)), Times.Once);
        }
    }

    // Testable subclass to expose protected methods
    public class TestableCounterPresenter : CounterPresenter
    {
        public TestableCounterPresenter(ICounterView view, CounterModel model, IEventPublisher eventBus)
            : base(view, model, eventBus) { }
        public new void OnViewEvent(ViewEvent @event) => base.OnViewEvent(@event);
        public new void OnModelEvent(ModelEvent @event) => base.OnModelEvent(@event);
    }

    public class CounterPresenterTests
    {
        [Fact]
        public void OnViewEvent_IncrementRequestedEvent_IncrementsModelAndPublishesEvent()
        {
            var eventBusMock = new Mock<IEventPublisher>();
            var model = new CounterModel(eventBusMock.Object);
            var viewMock = new Mock<ICounterView>();
            var presenter = new TestableCounterPresenter(viewMock.Object, model, eventBusMock.Object);

            presenter.OnViewEvent(new IncrementRequestedEvent());

            Assert.Equal(1, model.Count); // State change
            eventBusMock.Verify(e => e.Publish(It.Is<CounterUpdatedEvent>(ev => ev.NewCount == 1)), Times.Once); // Event published
        }

        [Fact]
        public void OnModelEvent_CounterUpdatedEvent_UpdatesView()
        {
            var viewMock = new Mock<ICounterView>();
            var model = new CounterModel(new Mock<IEventPublisher>().Object);
            var eventBusMock = new Mock<IEventPublisher>();
            var presenter = new TestableCounterPresenter(viewMock.Object, model, eventBusMock.Object);

            presenter.OnModelEvent(new CounterUpdatedEvent(5));
            viewMock.Verify(v => v.UpdateCount(5), Times.Once);
        }
    }
}
