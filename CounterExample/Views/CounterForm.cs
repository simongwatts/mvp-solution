using CounterExample.Events;
using MvpCore.Events;

namespace CounterExample.Views
{
    public partial class CounterForm : Form, ICounterView
    {
        private readonly IEventPublisher _eventBus;

        public CounterForm(IEventPublisher eventBus)
        {
            _eventBus = eventBus;
            InitializeComponent();
            btnIncrement.Click += (s, e) =>
                _eventBus.Publish(new IncrementRequestedEvent());
        }

        public void ShowError(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void UpdateCount(int count) => lblCount.Text = count.ToString();
    }
}